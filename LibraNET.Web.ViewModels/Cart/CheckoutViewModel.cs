using LibraNET.Web.ViewModels.Book;
using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.ApplicationUser;
using static LibraNET.Common.ValidationConstants.Order;

namespace LibraNET.Web.ViewModels.Cart
{
	public class CheckoutViewModel
	{
		public CheckoutViewModel()
		{
			Books = new List<BookCartViewModel>();
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

		[Required]
		[StringLength(TownNameMaxLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
			MinimumLength = TownNameMinLength)]
		public string Town { get; set; } = null!;

		[Required]
		[Display(Name = "Post Code")]
		[StringLength(PostCodeLength,
			ErrorMessage = "The {0} must be {1} characters long.",
			MinimumLength = PostCodeLength)]
		public string PostCode { get; set; } = null!;

		[Required]
		[Display(Name = "Street, №")]
		[StringLength(AddressMaxLength,
			ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
			MinimumLength = AddressMinLength)]
		public string Address { get; set; } = null!;

		public ICollection<BookCartViewModel> Books { get; set; }
	}
}
