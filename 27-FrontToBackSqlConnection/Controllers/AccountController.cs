using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser? user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == loginVM.UsernameOrEmail || u.Email == loginVM.UsernameOrEmail);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Username or Email is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersitent, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is blocked, please try again later!");
                return View();
            }

            if (!result.Succeeded) 
            {
                ModelState.AddModelError(string.Empty, "Username or Email is incorrect!");
                return View();
            }



            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString()});
        //    }

        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}
    }
}
