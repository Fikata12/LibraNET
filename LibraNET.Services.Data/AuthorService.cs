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

        public async Task<AuthorFormModel> GetByIdAsync(string id)
        {
            return mapper
                .Map<AuthorFormModel>(await context.Authors
                .FirstAsync(a => a.Id.Equals(Guid.Parse(id))));
        }

        public async Task<string> EditAndReturnIdAsync(AuthorFormModel model, string id)
        {
            var author = await context.Authors
                .FirstOrDefaultAsync(a => a.Id.Equals(Guid.Parse(id)));

            author!.Name = model.Name;
            author.ImageId = Guid.Parse(model.ImageId!);
            author.Description = model.Description;

            await context.SaveChangesAsync();

            return author.Id.ToString();
        }

        public async Task<string?> GetImageIdAsync(string id)
        {
            return (await context.Authors
                .FirstOrDefaultAsync(a => a.Id.Equals(Guid.Parse(id))))?
                .ImageId.ToString();
        }
    }
}
