using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;


namespace LibraNET.Areas.Admin.Controllers
{
	public class BookController : BaseAdminController
	{
		private readonly IBookService bookService;
		private readonly IAuthorService authorService;
		private readonly ICategoryService categoryService;
		private readonly IImageService imageService;

		public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService,
			IImageService imageService)
		{
			this.bookService = bookService;
			this.authorService = authorService;
			this.categoryService = categoryService;
			this.imageService = imageService;
		}

		public async Task<IActionResult> Add()
		{
			try
			{
				BookFormModel model = new BookFormModel
				{
					Authors = await authorService.AllForDropdownAsync(),
					Categories = await categoryService.AllForDropdownAsync()
				};
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookFormModel model)
		{
			try
			{
				if (!await categoryService.ExistsByIdAsync(model.SelectedCategoriesIds))
				{
					ModelState.AddModelError(nameof(model.SelectedCategoriesIds), "Selected category does not exist!");
				}

				if (!await authorService.ExistsByIdAsync(model.SelectedAuthorsIds))
				{
					ModelState.AddModelError(nameof(model.SelectedAuthorsIds), "Selected author does not exist!");
				}

				if (model.SelectedAuthorsIds.Count > 5)
				{
					ModelState.AddModelError(nameof(model.SelectedAuthorsIds), "Too much selected authors!");
				}

				if (model.SelectedCategoriesIds.Count > 5)
				{
					ModelState.AddModelError(nameof(model.SelectedCategoriesIds), "Too much selected categories!");
				}

				if (model.ISBN != null && await bookService.ExistsByIsbnAsync(model.ISBN))
				{
					ModelState.AddModelError(nameof(model.ISBN), "Already exists book with the same ISBN!");
				}

				string[] supportedTypes = new[] { "image/jpeg", "image/jpg", "image/png" };
				if (!supportedTypes.Contains(model.Image.ContentType))
				{
					ModelState.AddModelError(nameof(model.Image), "Invalid content type!");
				}

				if (!ModelState.IsValid)
				{
					model.Authors = await authorService.AllForDropdownAsync();
					model.Categories = await categoryService.AllForDropdownAsync();

					return View(model);
				}

				var imageId = await imageService.UploadBookImageAsync(model.Image);

				model.ImageId = imageId;
				var bookId = await bookService.AddAndReturnIdAsync(model);

				TempData["Success"] = SuccessfulBookCreation;
				return RedirectToAction("Details", "Book", new { id = bookId, area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookCreation;

				model.Authors = await authorService.AllForDropdownAsync();
				model.Categories = await categoryService.AllForDropdownAsync();

				return View(model);
			}
		}

		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				var model = await bookService.GetByIdAsync(id);
				model.Authors = await authorService.AllForDropdownAsync();
				model.Categories = await categoryService.AllForDropdownAsync();
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(BookFormModel model, string id)
		{
			try
			{
				if (!await categoryService.ExistsByIdAsync(model.SelectedCategoriesIds))
				{
					ModelState.AddModelError(nameof(model.SelectedCategoriesIds), "Selected category does not exist!");
				}

				if (!await authorService.ExistsByIdAsync(model.SelectedAuthorsIds))
				{
					ModelState.AddModelError(nameof(model.SelectedAuthorsIds), "Selected author does not exist!");
				}

				if (model.SelectedAuthorsIds.Count > 5)
				{
					ModelState.AddModelError(nameof(model.SelectedAuthorsIds), "Too much selected authors!");
				}

				if (model.SelectedCategoriesIds.Count > 5)
				{
					ModelState.AddModelError(nameof(model.SelectedCategoriesIds), "Too much selected categories!");
				}

				if (model.ISBN != null && await bookService.ExistsByIsbnAsync(model.ISBN))
				{
					ModelState.AddModelError(nameof(model.ISBN), "Already exists book with the same ISBN!");
				}

				string[] supportedTypes = new[] { "image/jpeg", "image/jpg", "image/png" };
				if (!supportedTypes.Contains(model.Image.ContentType))
				{
					ModelState.AddModelError(nameof(model.Image), "Invalid content type!");
				}

				if (!ModelState.IsValid)
				{
					model.Authors = await authorService.AllForDropdownAsync();
					model.Categories = await categoryService.AllForDropdownAsync();
					return View(model);
				}

				var imageId = await bookService.GetImageIdAsync(id);
				model.ImageId = imageId;

				await imageService.EditBookImageAsync(model.Image, model.ImageId!);

				var bookId = await bookService.EditAndReturnIdAsync(model, id);

				TempData["Success"] = SuccessfulBookEdit;
				return RedirectToAction("Details", "Book", new { id = bookId, area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookEdit;

				model.Authors = await authorService.AllForDropdownAsync();
				model.Categories = await categoryService.AllForDropdownAsync();

				return View(model);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{

				await bookService.DeleteAsync(id);

				TempData["Success"] = SuccessfulBookDeletion;
				return RedirectToAction("All", "Book", new { area = "" });
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookDeletion;
				return RedirectToAction("All", "Book", new { area = "" });
			}
		}

		public async Task<IActionResult> Image(string id)
		{
			var imageId = await bookService.GetImageIdAsync(id);
			if (imageId == null)
			{
				return NotFound();
			}
			var imageName = imageService.GetBookImageNameById(imageId);
			return Json(imageName);
		}
	}
}
