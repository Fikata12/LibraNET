using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		public async Task<IActionResult> Account()
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				var model = await userService.GetByIdAsync(userId);

				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AccountViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View("Account", model);
				}

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				await userService.EditAsync(model, userId);
			}
			catch (Exception)
			{
				TempData["Error"] = GeneralErrorMessage;

				return View("Account", model);
			}

			return RedirectToAction("Account");
		}
	}
}
