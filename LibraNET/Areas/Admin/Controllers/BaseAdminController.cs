using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class BaseAdminController : Controller
	{
		protected IActionResult GeneralError()
		{
			TempData["Error"] = GeneralErrorMessage;

			return RedirectToAction("Index", "Home");
		}
	}
}
