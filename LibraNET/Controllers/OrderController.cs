using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LibraNET.Common.NotificationMessagesConstants;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Controllers
{
	public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (await cartService.CountAsync(userId) < 1)
                {
                    return RedirectToAction("Index", "Cart");
                }

                if (!ModelState.IsValid)
                {
                    return View("Checkout", model);
                }

                await orderService.PlaceOrderAsync(model, userId);

                TempData["Success"] = SuccessfullyPlacedOrder;

                return RedirectToAction("Account", "User");
            }
            catch (Exception)
            {
                TempData["Error"] = GeneralErrorMessage;

                return View("Checkout", model);
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.IsInRole(AdminRoleName) || User.IsInRole(SuperAdminRoleName) || await orderService.IsOwner(userId, id))
                {
                    var model = await orderService.GetByIdAsync(id);
                    return View(model);
                }
            }
            catch (Exception) { }

            return NotFound();
        }
    }
}
