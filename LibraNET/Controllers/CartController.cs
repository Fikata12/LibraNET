using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	public class CartController : BaseController
	{
		private readonly IBookService bookService;
		private readonly ICartService cartService;
		public CartController(IBookService bookService, ICartService cartService)
		{
			this.bookService = bookService;
			this.cartService = cartService;
		}
		public async Task<IActionResult> Index()
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var model = await cartService.GetCartAsync(userId);
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookDetailsViewModel model, string id)
		{
			try
			{
				if (model.Quantity < 1 || model.Quantity > (await bookService.AvailableCountAsync(id)))
				{
					TempData["Error"] = InvalidQuantity;
				}

				if (!await bookService.ExistsByIdAsync(id))
				{
					throw new Exception();
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.AddAsync(id, userId, model.Quantity);

				TempData["Success"] = SuccessfulAddToCart;
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAddToCart;
			}
			return RedirectToAction("Details", "Book", new { id });
		}
	}
}
