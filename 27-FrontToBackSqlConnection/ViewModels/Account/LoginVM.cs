using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class LoginVM
    {
        [MinLength(4)]
        [MaxLength(50)]
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersitent { get; set; }
    }
}
