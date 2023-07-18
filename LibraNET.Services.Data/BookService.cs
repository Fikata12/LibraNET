using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels;
using LibraNET.Web.ViewModels.Enums;
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

		public async Task<ICollection<HomeBookViewModel>> LastThreeBooksAsync()
		{
			return await context.Books
				.AsNoTracking()
				.OrderByDescending(b => b.PublicationDate)
				.Take(3)
				.ProjectTo<HomeBookViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<CurrentBooksServiceModel> CurrentBooksPageAsync(AllBooksViewModel model)
		{
			var booksQuery = context.Books.AsNoTracking();

			if (model.ChosenCategories.Any())
			{
				booksQuery = booksQuery
					.Where(b => model.ChosenCategories.Any(c => b.BooksCategories.Any(bc => c.Id == bc.CategoryId.ToString())));
			}

			if (model.ChosenAuthors.Any())
			{
				booksQuery = booksQuery
					.Where(b => model.ChosenAuthors.Any(a => b.BooksAuthors.Any(ba => a.Id == ba.AuthorId.ToString())));
			}

			if (!string.IsNullOrWhiteSpace(model.SearchString))
			{
				string wildCard = $"%{model.SearchString}%";

				booksQuery = booksQuery.Where(b => EF.Functions.Like(b.Title, wildCard) ||
										 b.ISBN != null ? EF.Functions.Like(b.ISBN!, wildCard) : false);
			}

			booksQuery = booksQuery.Where(b => b.Price >= model.ChosenMinPrice && b.Price <= model.ChosenMaxPrice);

			switch (model.BookSorting)
			{
				case BookSorting.PublicationDate:
					booksQuery = booksQuery.OrderBy(b => b.PublicationDate)
						.ThenBy(b => b.Title);
					break;
				case BookSorting.Rating:
					booksQuery = booksQuery.OrderByDescending(b => b.Ratings.Count != 0 ? (decimal)b.Ratings.Sum(r => r.Value) / b.Ratings.Count : 0)
						.ThenBy(b => b.Title);
					break;
				case BookSorting.Price:
					booksQuery = booksQuery.OrderBy(b => b.Price)
						.ThenBy(b => b.Title);
					break;
				default:
					booksQuery = booksQuery.OrderBy(b => b.Title);
					break;
			}

			ICollection<AllBooksBookViewModel> books = await booksQuery
				.Skip((model.CurrentPage - 1) * model.BooksPerPage)
				.Take(model.BooksPerPage)
				.ProjectTo<AllBooksBookViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();

			int allBooksCount = booksQuery.Count();

			return new CurrentBooksServiceModel
			{
				Books = books,
				AllBooksCount = allBooksCount
			};
		}

		public async Task<decimal> MinPrice()
		{
			return await context.Books.MinAsync(b => b.Price);
		}

		public async Task<decimal> MaxPrice()
		{
			return await context.Books.MaxAsync(b => b.Price);
		}
	}
}
