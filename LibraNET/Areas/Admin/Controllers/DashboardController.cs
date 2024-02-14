using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;


namespace LibraNET.Areas.Admin.Controllers
{
	public class DashboardController : BaseAdminController
    {
        private readonly IUserService userService;
        public DashboardController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
			var model = new AdminHomeViewModel()
            {
				CustomersCount = await userService.CustomersCountAsync(),
			    AdminsCount = await userService.AdminsCountAsync(),
			    SuperAdminsCount = await userService.SuperAdminsCountAsync(),
                TotalCount = await userService.CountAsync()
		    };

			return View(model);
        }

        public IActionResult Entities()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
