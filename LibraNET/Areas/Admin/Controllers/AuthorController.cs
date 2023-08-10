using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Areas.Admin.Controllers
{
	public class AuthorController : BaseAdminController
	{
		private readonly IAuthorService authorService;
		private readonly IImageService imageService;

		public AuthorController(IAuthorService authorService, IImageService imageService)
		{
			this.authorService = authorService;
			this.imageService = imageService;
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
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
				return RedirectToAction("Details", "Author", new { id = authorId, area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorCreation;

				return View(model);
			}
		}

		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				var model = await authorService.GetByIdAsync(id);
				return View(model);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(AuthorFormModel model, string id)
		{
			try
			{
				if (!await authorService.NameBelongsToIdAsync(model.Name, id))
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

				await authorService.EditAsync(model, id);

				TempData["Success"] = SuccessfulAuthorEdit;
				return RedirectToAction("Details", "Author", new { id, area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorEdit;

				return View(model);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await authorService.DeleteAsync(id);

				TempData["Success"] = SuccessfulAuthorDeletion;
				return RedirectToAction("All", "Author", new { area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulAuthorDeletion;
				return RedirectToAction("All", "Author", new { area = "" });
			}
		}

		public async Task<IActionResult> Image(string id)
		{
			try
			{
				var imageId = await authorService.GetImageIdAsync(id);
				var imageName = imageService.GetAuthorImageNameById(imageId);
				return Json(imageName);
			}
			catch (Exception)
			{
				return NotFound();
			}
		}
	}
}
