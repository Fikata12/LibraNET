using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using X.PagedList;
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

        public async Task<IActionResult> All([FromQuery] AllUsersViewModel model)
        {
            IEnumerable<UserViewModel> allUsers = memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);

            if (allUsers == null)
            {
                allUsers = await userService.AllAsync(model);

                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(3));

                this.memoryCache.Set(UsersCacheKey, allUsers, options);
            }

            model.Users = await allUsers.ToPagedListAsync(model.CurrentPage, UsersPerPage);
            model.AllUsersCount = allUsers.Count();

            return View(model);
        }

        [HttpPost]
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
    }
}
