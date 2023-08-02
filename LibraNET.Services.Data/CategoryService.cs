﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;
using LibraNET.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
    public class CategoryService : ICategoryService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public CategoryService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.ProjectTo<FiltersCategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<ICollection<CategoryViewModel>> AllForDropdownAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.ProjectTo<CategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

        public async Task<bool> ExistsByIdAsync(ICollection<string> ids)
		{
			foreach (var id in ids)
			{
				var doesExist = await context.Categories
					.AsNoTracking()
					.AnyAsync(c => c.Id.Equals(Guid.Parse(id)) && !c.IsDeleted);

				if (!doesExist)
				{
					return false;
				}
			}

			return true;
		}

		public async Task<bool> ExistsByIdAsync(string id)
		{
			return await context.Categories
				.AsNoTracking()
				.AnyAsync(c => c.Id.Equals(Guid.Parse(id)) && !c.IsDeleted);
		}

		public async Task<bool> ExistsByNameAsync(string name)
		{
			return await context.Categories
				.AsNoTracking()
				.AnyAsync(c => c.Name == name && !c.IsDeleted);
		}

		public async Task AddAsync(CategoryFormModel model)
		{
			await context.Categories.AddAsync(mapper.Map<Category>(model));
			await context.SaveChangesAsync();
		}

        public async Task<CategoryFormModel> GetByIdAsync(string id)
        {
            return mapper
                .Map<CategoryFormModel>(await context.Categories
                .FirstAsync(a => a.Id.Equals(Guid.Parse(id))));
        }

        public async Task EditAsync(CategoryFormModel model, string id)
        {
            var category = await context.Categories
                .FirstAsync(b => b.Id.Equals(Guid.Parse(id)));

            category.Name = model.Name;

            await context.SaveChangesAsync();
        }

		public async Task<ICollection<CategoryViewModel>> AllAsync(AllCategoriesViewModel model)
		{
			var categoriesQuery = context.Categories.AsNoTracking();

			if (!string.IsNullOrWhiteSpace(model.SearchString))
			{
				string wildCard = $"%{model.SearchString}%";

				categoriesQuery = categoriesQuery.Where(c => EF.Functions.Like(c.Name, wildCard) ||
												   EF.Functions.Like(c.Id.ToString(), wildCard));
			}

			ICollection<CategoryViewModel> categories = await categoriesQuery
				.Where(c => !c.IsDeleted)
				.ProjectTo<CategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();

			return categories;
		}

		public async Task DeleteAsync(string id)
		{
			var category = context.Categories
				.First(c => c.Id.Equals(Guid.Parse(id)));

			category.IsDeleted = true;
			await context.SaveChangesAsync();
		}
	}
}
