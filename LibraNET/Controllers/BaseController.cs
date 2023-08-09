using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
        protected IActionResult GeneralError()
        {
            TempData["Error"] = GeneralErrorMessage;

            return RedirectToAction("Index", "Home");
        }
    }
}
