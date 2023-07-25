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
		}
        [Required]
		[MaxLength(TitleMaxLength)]
		[MinLength(TitleMinLength)]
		public string Title { get; set; } = null!;

		[MaxLength(ISBNLength)]
		[MinLength(ISBNLength)]
		public string? ISBN { get; set; }

		[Required]
		public DateTime PublicationDate { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLength)]
		[MinLength(DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Range(PageCountMin, PageCountMax)]
		public int PageCount { get; set; }

		[Required]
		[MaxLength(LanguageMaxLength)]
		[MinLength(LanguageMinLength)]
		public string Language { get; set; } = null!;

		[Required]
		public IFormFile Image { get; set; } = null!;

		public string? ImageId { get; set; }

		[Required]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		[Required]
		[Range(CountMinValue, CountMaxValue)]
		public int AvailableCount { get; set; }

		[Required]
		[MaxLength(PublisherNameMaxLength)]
		[MinLength(PublisherNameMinLength)]
		public string PublisherName { get; set; } = null!;

		[Required]
		public string AuthorId { get; set; } = null!;

		[Required]
		public string CategoryId { get; set; } = null!;


		public ICollection<BookAuthorViewModel> Authors { get; set; }


		public ICollection<BookCategoryViewModel> Categories { get; set; }
	}
}
