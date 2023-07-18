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

			if (model.ChosenMinPrice == 0)
			{
				model.ChosenMinPrice = model.MinPrice;
			}

			if (model.ChosenMaxPrice == 0)
			{
				model.ChosenMaxPrice = model.MaxPrice;
			}

			var serviceModel = await bookService.CurrentBooksPageAsync(model);

			model.Books = serviceModel.Books;
			model.AllBooksCount = serviceModel.AllBooksCount;



			model.Categories = await categoryService.AllAsync();

			model.Authors = await authorService.AllAsync();

			return View(model);
		}
	}
}
