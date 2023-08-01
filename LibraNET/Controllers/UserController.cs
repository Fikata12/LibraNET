using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All([FromQuery] AllUsersViewModel model)
        {
            var allUsers = await userService.AllAsync(model);

            model.Users = await allUsers.ToPagedListAsync(model.CurrentPage, EntitiesPerPage);
            model.AllUsersCount = allUsers.Count;

            return View(model);
        }
    }
}
