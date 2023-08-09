using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRoleName)]
	public class BaseAdminController : Controller
	{
		protected IActionResult GeneralError()
		{
			TempData["Error"] = GeneralErrorMessage;

			return RedirectToAction("Index", "Home");
		}
	}
}
