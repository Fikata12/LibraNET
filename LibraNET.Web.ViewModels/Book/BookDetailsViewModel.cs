﻿using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;
using LibraNET.Web.ViewModels.Comment;
using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Comment;

namespace LibraNET.Web.ViewModels.Book
{
	public class BookDetailsViewModel
	{
		public BookDetailsViewModel()
		{
			Authors = new List<BookAuthorViewModel>();
			Categories = new List<CategoryViewModel>();
			Comments = new List<CommentViewModel>();
			Ratings = new List<int>();
		}
		public string Id { get; set; } = null!;

		public string Title { get; set; } = null!;

		public string? ISBN { get; set; }

		public DateTime PublicationDate { get; set; }

		public string Description { get; set; } = null!;

		public int PageCount { get; set; }

		public string Language { get; set; } = null!;

		public string ImageId { get; set; } = null!;

		public decimal Price { get; set; }

		public int AvailableCount { get; set; }

		public string PublisherName { get; set; } = null!;

		public DateTime AddedDate { get; set; }

		public int OrdersCount { get; set; }

		public int Quantity { get; set; }

		public bool IsFavorite { get; set; }
		
		[Range(1, 5)]
		public int? Rating { get; set; }

		[StringLength(CommentMaxLength,
			MinimumLength = CommentMinLength,
			ErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.")]
		public string Comment { get; set; } = null!;

		public IList<BookAuthorViewModel> Authors { get; set; }

		public IList<CategoryViewModel> Categories { get; set; }

		public IList<CommentViewModel> Comments { get; set; }

		public IList<int> Ratings { get; set; }
	}
}
