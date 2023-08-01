﻿using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

		public UserController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All([FromQuery]AllUsersViewModel model)
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
	}
}
