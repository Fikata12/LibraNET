using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;
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

		public async Task<ICollection<BookCategoryViewModel>> AllForDropdownAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.ProjectTo<BookCategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

        public async Task<bool> ExistsByIdAsync(ICollection<string> ids)
		{
			var existingIds = await context.Categories.Select(c => c.Id.ToString()).ToListAsync();

			bool result = ids.All(id => existingIds.Any(eid => eid == id));

			return result;
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
    }
}
