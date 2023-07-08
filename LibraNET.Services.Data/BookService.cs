using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class BookService : IBookService
	{
		private readonly LibraNetDbContext context;
        private readonly IMapper mapper;

        public BookService(LibraNetDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<BookIndexViewModel>> GetNewestBooks()
        {
            return await context.Books
                .AsNoTracking()
                .OrderByDescending(b => b.PublicationDate)
                .Take(3)
                .ProjectTo<BookIndexViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
