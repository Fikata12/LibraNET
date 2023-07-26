using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Book;

namespace LibraNET.Web.ViewModels.Book
{
    public class BookFormModel
    {
        public BookFormModel()
        {
            Authors = new List<BookAuthorViewModel>();
            Categories = new List<BookCategoryViewModel>();
            SelectedAuthorsIds = new List<string>();
            SelectedCategoriesIds = new List<string>();
        }
        [Required]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
        public string Title { get; set; } = null!;

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid ISBN.")]
        [StringLength(ISBNLength,
            MinimumLength = ISBNLength,
            ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
        public string? ISBN { get; set; }

        [Required]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Page Count")]
        [Range(PageCountMin, PageCountMax)]
        public int PageCount { get; set; }

        [Required]
        [StringLength(LanguageMaxLength,
            MinimumLength = LanguageMinLength,
            ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
        public string Language { get; set; } = null!;

        [Required]
        public IFormFile Image { get; set; } = null!;

        public string? ImageId { get; set; }

        [Required]
        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Available Count")]
        [Range(CountMinValue, CountMaxValue)]
        public int AvailableCount { get; set; }

        [Required]
        [Display(Name = "Publisher")]
        [StringLength(PublisherNameMaxLength,
            MinimumLength = PublisherNameMinLength,
            ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
        public string PublisherName { get; set; } = null!;

        [Required]
        [Display(Name = "Authors")]
        public ICollection<string> SelectedAuthorsIds { get; set; }

        [Required]
        [Display(Name = "Categories")]
        public ICollection<string> SelectedCategoriesIds { get; set; }

        public ICollection<BookAuthorViewModel> Authors { get; set; }

        public ICollection<BookCategoryViewModel> Categories { get; set; }
    }
}
