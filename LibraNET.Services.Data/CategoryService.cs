using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
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
	}
}
