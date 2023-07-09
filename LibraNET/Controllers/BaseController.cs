using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraNET.Controllers
{
	[Authorize]
	[AutoValidateAntiforgeryToken]
	public class BaseController : Controller
	{

	}
}
