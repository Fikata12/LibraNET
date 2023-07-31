using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Author;

namespace LibraNET.Web.ViewModels.Author
{
	public class AuthorFormModel
	{
		[Required]
		[StringLength(NameMaxLength,
	MinimumLength = NameMinLength,
	ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength,
			ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
		public string Description { get; set; } = null!;

		[Required]
		public IFormFile Image { get; set; } = null!;

		public string? ImageId { get; set; }
	}
}
