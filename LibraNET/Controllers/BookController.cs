using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;
using static LibraNET.Common.NotificationMessagesConstants;
using static LibraNET.Common.ValidationConstants.Rating;
using static LibraNET.Common.ValidationConstants.Comment;

namespace LibraNET.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;
		private readonly IAuthorService authorService;
		private readonly ICategoryService categoryService;
		private readonly IRatingService ratingService;
		private readonly ICommentService commentService;

		public BookController(IBookService bookService, IAuthorService authorService,
			ICategoryService categoryService, IRatingService ratingService, ICommentService commentService)
		{
			this.bookService = bookService;
			this.authorService = authorService;
			this.categoryService = categoryService;
			this.ratingService = ratingService;
			this.commentService = commentService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] AllBooksViewModel model)
		{
			model.MinPrice = Convert.ToInt32(Math.Floor(await bookService.MinPriceAsync()));
			model.MaxPrice = Convert.ToInt32(Math.Ceiling(await bookService.MaxPriceAsync()));

			if (model.SelectedMinPrice == 0)
			{
				model.SelectedMinPrice = model.MinPrice;
			}

			if (model.SelectedMaxPrice == 0)
			{
				model.SelectedMaxPrice = model.MaxPrice;
			}


			model.Authors = await authorService.AllForFiltersAsync();

			foreach (var id in model.SelectedAuthorsIds)
			{
				var author = model.Authors.FirstOrDefault(a => a.Id == id);
				if (author != null)
				{
					author.IsSelected = true;
				}
			}

			model.Categories = await categoryService.AllForFiltersAsync();

			foreach (var id in model.SelectedCategoriesIds)
			{
				var category = model.Categories.FirstOrDefault(a => a.Id == id);
				if (category != null)
				{
					category.IsSelected = true;
				}
			}

			var allBooks = await bookService.AllAsync(model);

			model.Books = await allBooks.ToPagedListAsync(model.CurrentPage, BooksPerPage);

			return View(model);
		}

		[AllowAnonymous]
		public async Task<IActionResult> Details(string id)
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var model = await bookService.GetByIdAsync(id, userId);
				return View(model);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Rate(string id, int rating)
		{
			try
			{
				if (!User!.Identity!.IsAuthenticated)
				{
					string returnUrl = $"/Book/Details/{id}";
					return RedirectToPage("/Account/Login", new { area = "Identity", returnUrl });
				}

				if (rating < RatingMinValue || rating > RatingMaxValue)
				{
					TempData["Error"] = InvalidRating;
					return RedirectToAction("Details", "Book", new { id });
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await ratingService.RateBookAsync(id, userId, rating);
				return RedirectToAction("Details", "Book", new { id });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookRate;
				return NotFound();
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Comment(string id, string comment)
		{
			try
			{
				if (!User!.Identity!.IsAuthenticated)
				{
					string returnUrl = $"/Book/Details/{id}";
					return RedirectToPage("/Account/Login", "", new { area = "Identity", returnUrl }, "comments");
				}

				comment = comment.Trim();

				if (comment.Length < CommentMinLength || comment.Length > CommentMaxLength)
				{
					TempData["Error"] = InvalidComment;
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await commentService.AddComment(id, userId, comment);
				return RedirectToAction("Details", "Book", new { id }, "comments");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookComment;
				return NotFound();
			}
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ToggleFavorite(string id)
		{
			try
			{
				if (!User!.Identity!.IsAuthenticated)
				{
					string returnUrl = $"/Book/Details/{id}";
					return RedirectToPage("/Account/Login", new { area = "Identity", returnUrl });
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await bookService.ToggleFavoriteAsync(id, userId);
				return RedirectToAction("Details", "Book", new { id });
			}
			catch (Exception)
			{
				TempData["Error"] = GeneralErrorMessage;
				return NotFound();
			}
		}

		public async Task<IActionResult> Favorites([FromQuery] FavoriteViewModel model)
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				var favoriteBooks = await bookService.AllFavoritesAsync(model, userId);

				model.Books = await favoriteBooks.ToPagedListAsync(model.CurrentPage, BooksPerPage);
				model.AllBooksCount = favoriteBooks.Count;

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[AllowAnonymous]
		public async Task<IActionResult> CommentsCount(string id)
		{
			try
			{
				var count = await bookService.CommentsCountAsync(id);
				return Json(count);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}
	}
}
