using LibraNET.Data.Models;
using LibraNET.Services.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	public class UserController : BaseController
	{
		private readonly IUserService userService;
		private readonly UserManager<ApplicationUser> userManager;

		public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
		{
			this.userService = userService;
			this.userManager = userManager;
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> All([FromQuery] AllUsersViewModel model)
		{
			var allUsers = await userService.AllAsync(model);

			model.Users = await allUsers.ToPagedListAsync(model.CurrentPage, UsersPerPage);
			model.AllUsersCount = allUsers.Count;

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> MakeAdmin(string id)
		{
			var user = await userManager.FindByIdAsync(id);
			if (user == null)
			{
				TempData["Error"] = UserNotFound;
				return RedirectToAction("All", "User");
			}

			if (await userManager.IsInRoleAsync(user, "Admin"))
			{
				TempData["Warning"] = TheUserIsAdmin;
				return RedirectToAction("All", "User");
			}

			var addToAdminRoleResult = await userManager.AddToRoleAsync(user, "Admin");

			if (!addToAdminRoleResult.Succeeded)
			{
				TempData["Error"] = UnsuccessfulUserAdminify;
				return RedirectToAction("All", "User");
			}

			TempData["Success"] = SuccessfulUserAdminify;
			return RedirectToAction("All", "User");
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
