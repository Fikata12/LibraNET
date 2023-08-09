using LibraNET.Web.ViewModels.Order;
using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.ApplicationUser;


namespace LibraNET.Web.ViewModels.User
{
	public class AccountViewModel
	{
        public AccountViewModel()
        {
			Orders = new List<OrderViewModel>();
        }
        [Required]
		[Display(Name = "First Name")]
		[StringLength(FirstNameMaxLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
			MinimumLength = FirstNameMinLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[Display(Name = "Last Name")]
		[StringLength(LastNameMaxLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
			MinimumLength = LastNameMinLength)]
		public string LastName { get; set; } = null!;

		[Required]
		[Display(Name = "Phone Number")]
		[StringLength(PhoneNumberMaxLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
			MinimumLength = PhoneNumberMinLength)]
		[RegularExpression(PhoneNumberRegex,
			ErrorMessage = "Enter a valid Phone Number.")]
		public string PhoneNumber { get; set; } = null!;

		public ICollection<OrderViewModel> Orders { get; set; }
	}
}
