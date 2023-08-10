using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LibraNET.Controllers
{
	public class HomeController : BaseController
	{
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var books = await bookService.LastThreeBooksAsync();
            return View(books);
        }

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }
    }
}