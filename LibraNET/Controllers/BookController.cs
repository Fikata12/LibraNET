using LibraNET.Services.Data.Contracts;
using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraNET.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;
		private readonly IAuthorService authorService;
		private readonly ICategoryService categoryService;

		public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService)
		{
			this.bookService = bookService;
			this.authorService = authorService;
			this.categoryService = categoryService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery]AllBooksViewModel model)
		{
			model.MinPrice = Convert.ToInt32(Math.Floor(await bookService.MinPrice()));
			model.MaxPrice = Convert.ToInt32(Math.Ceiling(await bookService.MaxPrice()));

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

			var serviceModel = await bookService.CurrentBooksPageAsync(model);

			model.Books = serviceModel.Books;
			model.AllBooksCount = serviceModel.AllBooksCount;

			return View(model);
		}
	}
}
