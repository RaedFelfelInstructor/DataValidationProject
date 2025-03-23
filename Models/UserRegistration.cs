using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataValidationProject.Models
{
    public class UserRegistration
    {
        [Display(Name ="Username")]
        [Required(ErrorMessage ="Username is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Username can only contain letters, numbers, underscores and hyphens")]
        [Remote(action: "CheckUsername", controller:"Account", ErrorMessage = "This username is already taken")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
           ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The Password and Confirmation password do not match!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Phone number format: (123) 456-7890 or 123-456-7890")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
