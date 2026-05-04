using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class HomeController: Controller
    {
        public ViewResult Index() {
            //return "APA103";

            //return Content("APA103");

            //var student = new JsonResult(new { Id = 1, name = "Ali", surname = "Quliyev" });
            //return student;

            return View("Index");
        }

        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }
            return RedirectToAction(nameof(Index), "Product");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
