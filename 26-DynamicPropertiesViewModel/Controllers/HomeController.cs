using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Huseyin", Age = 20 },
            new Student { Id = 2, Name = "Ali", Age = 22},
            new Student {Id = 3, Name = "Ramin", Age = 21},
        };

        List<Teacher> teachers = new List<Teacher>
        {
            new Teacher { Id = 1, Name = "Qasim", Salary = 1000},
            new Teacher { Id = 2, Name = "Mehemmed", Salary = 2000},
            new Teacher { Id = 3, Name = "Tural", Salary = 1500},
        };

        public IActionResult Index()
        {
            var a = 40;

            dynamic b = 80;

            a = a + 50;

            b = b + 50;

            //ViewBag.Students = students;

            //ViewData["Students"] = students;

            //TempData["Name"] = "Ramin";

            HomeVM homeVM = new()
            {
                Teachers = teachers,
                Students = students
            };

            return View(homeVM);
        }

        public IActionResult Details()
        {
            return View();
        }

        [Route("korporativ-satislar")]
        public IActionResult CorporativeSales()
        {
            HomeVM homeVM = new()
            {
                Teachers = teachers,
                Students = students
            };

            return View(homeVM);
        }
    }
}
