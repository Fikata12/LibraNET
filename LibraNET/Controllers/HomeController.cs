using LibraNET.Web.ViewModels;
using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetNewestBooks();
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}