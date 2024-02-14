using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.NotificationMessagesConstants;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Areas.Admin.Controllers
{
	public class CategoryController : BaseAdminController
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CategoryFormModel model)
		{
			try
			{
				if (await categoryService.ExistsByNameAsync(model.Name))
				{
					ModelState.AddModelError(nameof(model.Name), "Already exists category with the same name!");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}
				await categoryService.AddAsync(model);

				TempData["Success"] = SuccessfulCategoryCreation;
				return RedirectToAction("All", "Category");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulCategoryCreation;

				return View(model);
			}
		}

		public async Task<IActionResult> Edit(string id)
		{
			try
			{
				var model = await categoryService.GetByIdAsync(id);
				return View(model);
			}
			catch (Exception)
			{
				return GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CategoryFormModel model, string id)
		{
			try
			{
				if (!await categoryService.NameBelongsToIdAsync(model.Name, id))
				{
					ModelState.AddModelError(nameof(model.Name), "Already exists category with the same name!");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				await categoryService.EditAsync(model, id);

				TempData["Success"] = SuccessfulCategoryEdit;
				return RedirectToAction("All", "Category");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulCategoryEdit;

				return View(model);
			}
		}

		public async Task<IActionResult> All([FromQuery] AllCategoriesViewModel model)
		{
			var allCategories = await categoryService.AllAsync(model);

			model.Categories = await allCategories.ToPagedListAsync(model.CurrentPage, AdminCategoriesPerPage);
			model.AllCategoriesCount = allCategories.Count;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await categoryService.DeleteAsync(id);

				TempData["Success"] = SuccessfulCategoryDeletion;
				return RedirectToAction("All", "Category");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulCategoryDeletion;
				return RedirectToAction("All", "Category");
			}
		}
	}
}
