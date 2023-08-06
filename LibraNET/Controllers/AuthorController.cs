using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.NotificationMessagesConstants;
using static LibraNET.Common.GeneralApplicationConstants;
using LibraNET.Services.Data;
using System.Security.Claims;

namespace LibraNET.Controllers
{
	public class AuthorController : BaseController
	{
		private readonly IAuthorService authorService;
		private readonly IImageService imageService;

		public AuthorController(IAuthorService authorService, IImageService imageService)
		{
			this.authorService = authorService;
			this.imageService = imageService;
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add(AuthorFormModel model)
		{
			try
			{
				if (await authorService.ExistsByNameAsync(model.Name))
				{
					ModelState.AddModelError(nameof(model.Name), "Already exists author with the same name!");
				}

				string[] supportedTypes = new[] { "image/jpeg", "image/jpg", "image/png" };
				if (!supportedTypes.Contains(model.Image.ContentType))
				{
					ModelState.AddModelError(nameof(model.Image), "Invalid content type!");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				var imageId = await imageService.UploadAuthorImageAsync(model.Image);

				model.ImageId = imageId;
				var authorId = await authorService.AddAndReturnIdAsync(model);

				TempData["Success"] = SuccessfulAuthorCreation;
				return RedirectToAction("Details", "Author", new { id = authorId });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorCreation;

				return View(model);
			}
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				var model = await authorService.GetByIdAsync(id);
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(AuthorFormModel model, string id)
		{
			try
			{
				if (await authorService.ExistsByNameAsync(model.Name))
				{
					ModelState.AddModelError(nameof(model.Name), "Already exists author with the same name!");
				}

				string[] supportedTypes = new[] { "image/jpeg", "image/jpg", "image/png" };
				if (!supportedTypes.Contains(model.Image.ContentType))
				{
					ModelState.AddModelError(nameof(model.Image), "Invalid content type!");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				var imageId = await authorService.GetImageIdAsync(id);
				model.ImageId = imageId;

				await imageService.EditAuthorImageAsync(model.Image, model.ImageId!);

				var authorId = await authorService.EditAndReturnIdAsync(model, id);

				TempData["Success"] = SuccessfulAuthorEdit;
				return RedirectToAction("Details", "Author", new { id = authorId });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorEdit;

				return View(model);
			}
		}

		public async Task<IActionResult> All([FromQuery] AllAuthorsViewModel model)
		{
			var allAuthors = await authorService.AllAsync(model);

			model.Authors = await allAuthors.ToPagedListAsync(model.CurrentPage, AuthorsPerPage);
			model.AllAuthorsCount = allAuthors.Count;

			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await authorService.DeleteAsync(id);

				TempData["Success"] = SuccessfulAuthorDeletion;
				return RedirectToAction("All", "Author");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorDeletion;
				return RedirectToAction("All", "Author");
			}
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Image(string id)
		{
			var imageId = await authorService.GetImageIdAsync(id);
			if (imageId == null)
			{
				return NotFound();
			}
			var imageName = imageService.GetAuthorImageNameById(imageId);
			return Json(imageName);
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
				return GeneralError();
			}
		}
	}
}
