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
		public async Task<IActionResult> Add(string id, int quantity)
		{
			try
			{
				if (quantity < 1 || quantity > (await bookService.AvailableCountAsync(id)))
				{
					TempData["Error"] = InvalidQuantity;
					return RedirectToAction("Details", "Book", new { id });
				}

				if (!await bookService.ExistsByIdAsync(id))
				{
					throw new Exception();
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.AddAsync(id, userId, quantity);

				TempData["Success"] = SuccessfulAddToCart;
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAddToCart;
			}
			return RedirectToAction("Details", "Book", new { id });
		}

		[HttpPost]
		public async Task<IActionResult> Remove(string id)
		{
			try
			{
				if (!await bookService.ExistsByIdAsync(id))
				{
					throw new Exception();
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.RemoveAsync(id, userId);
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulRemoveFromCart;
			}
			return RedirectToAction("Index", "Cart");
		}

		[HttpPost]
		public async Task<IActionResult> ChangeQuantity(string id, int quantity)
		{
			try
			{
				if (quantity < 1 || quantity > (await bookService.AvailableCountAsync(id)))
				{
					TempData["Error"] = InvalidQuantity;
					return RedirectToAction("Index", "Cart", new { }, id);
				}

				if (!await bookService.ExistsByIdAsync(id))
				{
					throw new Exception();
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.ChangeQuantityAsync(id, userId, quantity);
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAddToCart;
			}
			return RedirectToAction("Index", "Cart", new { }, id);
		}


	}
}
