using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class AuthorService : IAuthorService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public AuthorService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync()
		{
			return await context.Authors
				.AsNoTracking()
				.ProjectTo<FiltersAuthorViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}
}
