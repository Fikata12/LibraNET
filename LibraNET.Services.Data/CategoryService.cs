using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class CategoryService : ICategoryService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;
		private readonly IBookService bookService;

		public CategoryService(LibraNetDbContext context, IMapper mapper, IBookService bookService)
		{
			this.context = context;
			this.mapper = mapper;
			this.bookService = bookService;
		}

		public async Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.Where(c => !c.IsDeleted)
				.ProjectTo<FiltersCategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<ICollection<CategoryViewModel>> AllForDropdownAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.Where(c => !c.IsDeleted)
				.ProjectTo<CategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

        public async Task<bool> ExistsByIdAsync(ICollection<string> ids)
		{
			foreach (var id in ids)
			{
				var doesExist = await context.Categories
					.AsNoTracking()
					.Where(c => !c.IsDeleted)
					.AnyAsync(c => c.Id.Equals(Guid.Parse(id)));

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
				.Where(c => !c.IsDeleted)
				.AnyAsync(c => c.Id.Equals(Guid.Parse(id)));
		}

		public async Task<bool> ExistsByNameAsync(string name)
		{
			return await context.Categories
				.AsNoTracking()
				.Where(c => !c.IsDeleted)
				.AnyAsync(c => c.Name == name);
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
				.AsNoTracking()
				.Where(b => !b.IsDeleted)
				.FirstAsync(a => a.Id.Equals(Guid.Parse(id))));
        }

        public async Task EditAsync(CategoryFormModel model, string id)
        {
            var category = await context.Categories
				.Where(c => !c.IsDeleted)
                .FirstAsync(c => c.Id.Equals(Guid.Parse(id)));

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
			var category = await context.Categories
				.Include(c => c.BooksCategories)
				.Where(c => !c.IsDeleted)
				.FirstAsync(c => c.Id.Equals(Guid.Parse(id)));

			category.IsDeleted = true;

			foreach (var bookCategory in category.BooksCategories)
			{
				await bookService.DeleteAsync(bookCategory.BookId.ToString());
			}

			await context.SaveChangesAsync();
		}

		public async Task<bool> NameBelongsToIdAsync(string name, string id)
		{
			return !await context.Categories
				.AsNoTracking()
				.Where(c => !c.IsDeleted)
				.AnyAsync(c => !c.Id.Equals(Guid.Parse(id)) && c.Name == name);
		}
	}
}
