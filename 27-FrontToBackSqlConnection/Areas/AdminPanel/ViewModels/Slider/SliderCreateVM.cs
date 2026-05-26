using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Slider
{
    public class SliderCreateVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }

        [Required(ErrorMessage = "Photo is required!")]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
