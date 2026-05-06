using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //List<Slider> _sliders = new List<Slider>
        //{
        //    new Slider {Title = "Basliq-1", Subtitle = "Komekci Basliq-1", Description = "Gullerden Qalmadi", Image = "1-1-524x617.png", Order = 3, isDeleted = false},
        //    new Slider {Title = "Basliq-2", Subtitle = "Komekci Basliq-2", Description = "Indi esl istirahet vaxtidir", Image = "1-2-524x617.png", Order = 2, isDeleted = true},
        //    new Slider {Title = "Basliq-3", Subtitle = "Komekci Basliq-3", Description = "Gozel Tebiet", Image = "blueflower.webp", Order = 1, isDeleted = false},
        //};

        public IActionResult Index()
        {
            //_context.AddRange(_sliders);
            //_context.SaveChanges();

            List<Slider> sliders = _context.Sliders
                .OrderBy(s => s.Order)
                .Take(2)
                .Where(s => !s.isDeleted)
                .ToList();

            HomeVM homeVM = new()
            {
                Sliders = sliders
            };

            return View(homeVM);
        }
    }
}
