using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema_Project.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "The FirstName field is required.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "The LastName field is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        public string? UserName { get; set; }
    }
}