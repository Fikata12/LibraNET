using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            var serviceModel = await bookService.AllAsync(model);

            model.Books = await serviceModel.Books.ToPagedListAsync(model.CurrentPage, EntitiesPerPage);
            model.AllBooksCount = serviceModel.AllBooksCount;

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
            if (!await categoryService.ExistsByIdAsync(model.SelectedCategoriesIds))
            {
                ModelState.AddModelError(nameof(model.SelectedCategoriesIds), "Selected category does not exist!");
            }

            if (!await authorService.ExistsByIdAsync(model.SelectedAuthorsIds))
            {
                ModelState.AddModelError(nameof(model.SelectedAuthorsIds), "Selected author does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Authors = await authorService.AllForDropdownAsync();
                model.Categories = await categoryService.AllForDropdownAsync();

                return View(model);
            }
            try
            {
                var imageId = await imageService.UploadBookImageAsync(model.Image);

                model.ImageId = imageId;
                var bookId = await bookService.AddAndReturnIdAsync(model);

                TempData["Success"] = SuccessfulBookCreation;
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, UnsuccessfulBookCreation);

                model.Authors = await authorService.AllForDropdownAsync();
                model.Categories = await categoryService.AllForDropdownAsync();

                return View(model);
            }
        }
    }
}
