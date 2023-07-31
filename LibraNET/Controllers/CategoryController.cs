﻿using LibraNET.Services.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibraNET.Common.NotificationMessagesConstants;

namespace LibraNET.Controllers
{
	public class CategoryController : BaseController
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[Authorize(Roles = "Admin")]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Add(CategoryFormModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(model);
				}
				await categoryService.AddAsync(model);

				TempData["Success"] = SuccessfulCategoryCreation;
				return RedirectToAction("Index", "Home");
			}
			catch (Exception)
			{
				TempData["Error"] = UnsuccessfulCategoryCreation;

				return View(model);
			}
		}

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(CategoryFormModel model, string id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                await categoryService.EditAsync(model, id);

                TempData["Success"] = SuccessfulCategoryEdit;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["Error"] = UnsuccessfulCategoryEdit;

                return View(model);
            }
        }
    }
}