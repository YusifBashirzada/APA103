using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="Bos Olmaz")]
        [MaxLength(30)]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
