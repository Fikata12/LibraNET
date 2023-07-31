using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Category;

namespace LibraNET.Web.ViewModels.Category
{
	public class CategoryFormModel
	{
		[Required]
		[StringLength(NameMaxLength,
	MinimumLength = NameMinLength,
	ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
