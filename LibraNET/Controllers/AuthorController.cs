using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Controllers
{
	public class AuthorController : BaseController
	{
		private readonly IAuthorService authorService;

		public AuthorController(IAuthorService authorService)
		{
			this.authorService = authorService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] AllAuthorsViewModel model)
		{
			var allAuthors = await authorService.AllAsync(model);

			model.Authors = await allAuthors.ToPagedListAsync(model.CurrentPage, AuthorsPerPage);
			model.AllAuthorsCount = allAuthors.Count;

			return View(model);
		}

		[AllowAnonymous]
		public async Task<IActionResult> Details(string id)
		{
			try
			{
				var model = await authorService.GetDetailsAsync(id);
				return View(model);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}
	}
}
