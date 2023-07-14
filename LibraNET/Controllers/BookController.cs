using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraNET.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

		public BookController(IBookService bookService)
		{
			this.bookService = bookService;
		}
		public IActionResult All()
		{
			return View();
		}
	}
}
