using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static LibraNET.Common.GeneralApplicationConstants;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Areas.Admin.Controllers
{
	public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> allUsers = memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);

            if (allUsers == null)
            {
                allUsers = await userService.AllAsync();

                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                this.memoryCache.Set(UsersCacheKey, allUsers, options);
            }

            return View(allUsers);
        }

        [HttpPost]
        [Authorize(Roles = SuperAdminRoleName)]
        public async Task<IActionResult> MakeAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = UserNotFound;
                return RedirectToAction("All", "User");
            }

            if (await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData["Warning"] = TheUserIsAdmin;
                return RedirectToAction("All", "User");
            }

            var addToAdminRoleResult = await userManager.AddToRoleAsync(user, AdminRoleName);

            if (!addToAdminRoleResult.Succeeded)
            {
                TempData["Error"] = UnsuccessfulUserAdminify;
                return RedirectToAction("All", "User");
            }

            TempData["Success"] = SuccessfulUserAdminify;
            return RedirectToAction("All", "User");
        }

        [HttpPost]
        [Authorize(Roles = SuperAdminRoleName)]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                TempData["Error"] = UserNotFound;
                return RedirectToAction("All", "User");
            }

            if (!await userManager.IsInRoleAsync(user, AdminRoleName))
            {
                TempData["Warning"] = TheUserIsNotAdmin;
                return RedirectToAction("All", "User");
            }

            var removeFromAdminRoleResult = await userManager.RemoveFromRoleAsync(user, AdminRoleName);

            if (!removeFromAdminRoleResult.Succeeded)
            {
                TempData["Error"] = UnsuccessfulAdminRemoval;
                return RedirectToAction("All", "User");
            }

            TempData["Success"] = SuccessfulAdminRemoval;
            return RedirectToAction("All", "User");
        }
    }
}
