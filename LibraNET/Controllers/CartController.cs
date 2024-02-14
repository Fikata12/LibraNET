using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	public class CartController : BaseController
	{
		private readonly IBookService bookService;
		private readonly ICartService cartService;
		private readonly UserManager<ApplicationUser> userManager;
		public CartController(IBookService bookService, ICartService cartService, UserManager<ApplicationUser> userManager)
		{
			this.bookService = bookService;
			this.cartService = cartService;
			this.userManager = userManager;
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
		[AllowAnonymous]
		public async Task<IActionResult> Add(string id, int quantity)
		{
			try
			{
				if (!User!.Identity!.IsAuthenticated)
				{
					string returnUrl = $"/Book/Details/{id}";
					return RedirectToPage("/Account/Login", new { area = "Identity", returnUrl });
				}

				if (quantity < 1 || quantity > (await bookService.AvailableCountAsync(id)))
				{
					TempData["Error"] = InvalidQuantity;
					return RedirectToAction("Details", "Book", new { id });
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.AddAsync(id, userId, quantity);

				TempData["Success"] = SuccessfulAddToCart;
				return RedirectToAction("All", "Book");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAddToCart;
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Remove(string id)
		{
			try
			{
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

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				await cartService.ChangeQuantityAsync(id, userId, quantity);
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAddToCart;
			}
			return RedirectToAction("Index", "Cart", new { }, id);
		}

		public async Task<IActionResult> Checkout()
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (await cartService.CountAsync(userId) < 1)
				{
					return RedirectToAction("Index", "Cart");
				}
				var model = new CheckoutViewModel();

				model.Books = await cartService.GetCartAsync(userId);

				var user = await userManager.GetUserAsync(User);

				model.FirstName = user.FirstName!;
				model.LastName = user.LastName!;
				model.PhoneNumber = user.PhoneNumber!;

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}
	}
}
