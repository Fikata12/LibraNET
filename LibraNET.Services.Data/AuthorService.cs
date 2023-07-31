using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Author;
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

		public async Task<ICollection<BookAuthorViewModel>> AllForDropdownAsync()
		{
			return await context.Authors
				.AsNoTracking()
				.ProjectTo<BookAuthorViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<bool> ExistsByIdAsync(ICollection<string> ids)
		{
			var existingIds = await context.Authors.Select(c => c.Id.ToString()).ToListAsync();

			bool result = ids.All(id => existingIds.Any(eid => eid == id));

			return result;
		}

		public async Task<string> AddAndReturnIdAsync(AuthorFormModel model)
		{
			var author = mapper.Map<Author>(model);

			await context.Authors.AddAsync(author);
			await context.SaveChangesAsync();

			return author.Id.ToString();
		}
	}
}
