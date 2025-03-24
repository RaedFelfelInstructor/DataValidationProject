using System.ComponentModel.DataAnnotations;

namespace DataValidationProject.Models
{
    public class UserProfile
    {
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Full name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage="Name must be between 5 and 100 characters")]
        public string FullName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM-dd}", ApplyFormatInEditMode = true)]
        [PastDate(ErrorMessage = "Date of birth must be in past")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "age")]
        [Required(ErrorMessage = "age is required")]
        [Range(18,120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }

        [Display(Name = "annual Income")]
        [DataType(DataType.Currency)]
        [Range(0, 10000000, ErrorMessage ="Income must be between 0 and $10,000,000")]
        public decimal? AnnualIncome { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "website URL")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? WebsiteUrl { get; set; }

        [Display(Name = "Profile Bio")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage ="Bio cannot exceed 500 characters")]
        public string? Bio {  get; set; }

        [Display(Name = "Preferred Contact Method")]
        [Required(ErrorMessage = " Please select a preferred contact method")]
        public ContactMethod PreferredContactMethod { get; set; }
    }

    public enum ContactMethod {  Email, Phone, Mail }

    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is DateTime dateTime)
            {
                if (dateTime > DateTime.Today)
                {
                    return new ValidationResult(ErrorMessage ?? "Date must be in the past");
                }
            }
            return ValidationResult.Success!;
        }
    }
}
