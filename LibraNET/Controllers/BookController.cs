using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;
using static LibraNET.Common.NotificationMessagesConstants;
namespace LibraNET.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ICategoryService categoryService;
        private readonly IImageService imageService;

        public BookController(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, IImageService imageService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.categoryService = categoryService;
            this.imageService = imageService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllBooksViewModel model)
        {
            model.MinPrice = Convert.ToInt32(Math.Floor(await bookService.MinPriceAsync()));
            model.MaxPrice = Convert.ToInt32(Math.Ceiling(await bookService.MaxPriceAsync()));

            if (model.SelectedMinPrice == 0)
            {
                model.SelectedMinPrice = model.MinPrice;
            }

            if (model.SelectedMaxPrice == 0)
            {
                model.SelectedMaxPrice = model.MaxPrice;
            }


            model.Authors = await authorService.AllForFiltersAsync();

            foreach (var id in model.SelectedAuthorsIds)
            {
                var author = model.Authors.FirstOrDefault(a => a.Id == id);
                if (author != null)
                {
                    author.IsSelected = true;
                }
            }

            model.Categories = await categoryService.AllForFiltersAsync();

            foreach (var id in model.SelectedCategoriesIds)
            {
                var category = model.Categories.FirstOrDefault(a => a.Id == id);
                if (category != null)
                {
                    category.IsSelected = true;
                }
            }

            var allBooks = await bookService.AllAsync(model);

            model.Books = await allBooks.ToPagedListAsync(model.CurrentPage, BooksPerPage);
            model.AllBooksCount = allBooks.Count;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            catch (Exception)
            {
				TempData["Error"] = UnsuccessfulBookCreation;

				model.Authors = await authorService.AllForDropdownAsync();
                model.Categories = await categoryService.AllForDropdownAsync();

                return View(model);
            }
        }

		[Authorize(Roles = "Admin")]
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
		[Authorize(Roles = "Admin")]
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
				return RedirectToAction("Details", "Book", new { id = bookId });
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
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await bookService.DeleteAsync(id);

				TempData["Success"] = SuccessfulBookDeletion;
				return RedirectToAction("All", "Book");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulBookDeletion;
				return RedirectToAction("All", "Book");
			}
		}

		[AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var model = await bookService.GetByIdAsync(id, userId);
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
        }

        [Authorize(Roles = "Admin")]
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

		[HttpPost]
		public async Task<IActionResult> Rate(string id, int rate)
		{
			return NoContent();
		}
	}
}
