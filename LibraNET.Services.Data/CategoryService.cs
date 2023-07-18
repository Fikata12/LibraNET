using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels;
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

		public async Task<IList<CategoryViewModel>> AllAsync()
		{
			return await context.Categories
				.AsNoTracking()
				.ProjectTo<CategoryViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}
}
