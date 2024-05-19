using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required. ")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required. ")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "")]
        public bool RememberMe { get; set; }
    }
}
