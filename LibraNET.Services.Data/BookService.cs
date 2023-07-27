﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.Enums;
using Microsoft.EntityFrameworkCore;
using static LibraNET.Common.GeneralApplicationConstants;

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

		public async Task<ICollection<BookViewModel>> LastThreeBooksAsync()
		{
			return await context.Books
				.AsNoTracking()
				.Where(b => !b.IsDeleted)
				.OrderByDescending(b => b.PublicationDate)
				.Take(3)
				.ProjectTo<BookViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<CurrentBooksServiceModel> AllAsync(AllBooksViewModel model)
		{
			var booksQuery = context.Books.AsNoTracking();

			if (model.Categories.Any(c => c.IsSelected))
			{
				booksQuery = booksQuery
					.Where(b => b.BooksCategories.Any(bc => model.SelectedCategoriesIds.Contains(bc.CategoryId.ToString())));
			}

			if (model.Authors.Any(a => a.IsSelected))
			{
				booksQuery = booksQuery
					.Where(b => b.BooksAuthors.Any(ba => model.SelectedAuthorsIds.Contains(ba.AuthorId.ToString())));
			}

			if (!string.IsNullOrWhiteSpace(model.SearchString))
			{
				string wildCard = $"%{model.SearchString}%";

				booksQuery = booksQuery.Where(b => EF.Functions.Like(b.Title, wildCard) ||
										 (b.ISBN != null && EF.Functions.Like(b.ISBN!, wildCard)));
			}

			booksQuery = booksQuery.Where(b => b.Price >= model.SelectedMinPrice && b.Price <= model.SelectedMaxPrice);

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

			ICollection<BookViewModel> books = await booksQuery
				.Where(b =>  !b.IsDeleted)
				.ProjectTo<BookViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();

			int allBooksCount = booksQuery.Count();

			return new CurrentBooksServiceModel
			{
				Books = books,
				AllBooksCount = allBooksCount
			};
		}

		public async Task<decimal> MinPriceAsync()
		{
			return await context.Books.MinAsync(b => b.Price);
		}

		public async Task<decimal> MaxPriceAsync()
		{
			return await context.Books.MaxAsync(b => b.Price);
		}

		public async Task<string> AddAndReturnIdAsync(BookFormModel model)
		{
			var book = mapper.Map<Book>(model);

            await context.Books.AddAsync(book);
			await context.SaveChangesAsync();

			return book.Id.ToString();
		}

		public async Task<BookFormModel> GetByIdAsync(string id)
		{
			return mapper
				.Map<BookFormModel>(await context.Books
                .Include(b => b.BooksAuthors)
                .Include(b => b.BooksCategories)
                .FirstOrDefaultAsync(b => b.Id.Equals(Guid.Parse(id))));
		}

		public async Task<string> EditAndReturnIdAsync(BookFormModel model, string id)
		{
			var book = await context.Books
				.FirstAsync(b => b.Id.Equals(Guid.Parse(id)));

			book!.Title = model.Title;
			book.Description = model.Description;
			book.ISBN = model.ISBN;
			book.Price = model.Price;
			book.Language = model.Language;
			book.PublicationDate = model.PublicationDate;
			book.PageCount = model.PageCount;
			book.ImageId = Guid.Parse(model.ImageId!);
            book.AvailableCount = model.AvailableCount;
			book.PublisherName = model.PublisherName;

			book.BooksAuthors.Clear();
			book.BooksCategories.Clear();

			foreach (var authorId in model.SelectedAuthorsIds)
			{
				book.BooksAuthors.Add(new BookAuthor
				{
					AuthorId = Guid.Parse(authorId)
				});
			}

            foreach (var categoryId in model.SelectedCategoriesIds)
            {
                book.BooksCategories.Add(new BookCategory
                {
                    CategoryId = Guid.Parse(categoryId)
                });
            }

			return book.Id.ToString();
        }

		public async Task<string?> GetImageIdAsync(string bookId)
		{
			return (await context.Books
				.FirstOrDefaultAsync(b => b.Id.Equals(Guid.Parse(bookId))))?
				.ImageId.ToString();
		}
	}
}
