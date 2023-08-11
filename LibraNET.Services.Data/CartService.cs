using AutoMapper;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class CartService : ICartService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public CartService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		public async Task AddCartAsync(string userId)
		{
			await context.Carts.AddAsync(new Cart
			{
				UserId = Guid.Parse(userId),
			});
			await context.SaveChangesAsync();
		}
		public async Task AddAsync(string bookId, string userId, int quantity)
		{
			var cart = await context.Carts
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId)));

			var book = await context.Books
				.Where(b => !b.IsDeleted)
				.FirstAsync(b => b.Id.Equals(Guid.Parse(bookId)));

			var cartBook = await context.CartsBooks
				.Include(cb => cb.Book)
				.Include(cb => cb.Cart)
				.FirstOrDefaultAsync(cb => cb.Book == book && cb.Cart == cart);

			if (cartBook == null)
			{
				await context.CartsBooks.AddAsync(new CartBook
				{
					Cart = cart,
					Book = book,
					BookCount = quantity
				});

				await context.SaveChangesAsync();
				return;
			}

			cartBook.BookCount = quantity;
			await context.SaveChangesAsync();
		}

		public async Task<ICollection<BookCartViewModel>> GetCartAsync(string userId)
		{
			return mapper.Map<ICollection<BookCartViewModel>>(await context.CartsBooks
				.AsNoTracking()
				.Include(c => c.Book)
				.Where(c => c.Cart.UserId.Equals(Guid.Parse(userId)) && !c.Book.IsDeleted)
				.ToListAsync());
		}

		public async Task ChangeQuantityAsync(string bookId, string userId, int quantity)
		{
			var cart = await context.Carts
				.Include(c => c.CartsBooks)
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId)));

			var cartBook = cart.CartsBooks
				.First(cb => cb.BookId.Equals(Guid.Parse(bookId)));

			cartBook.BookCount = quantity;
			await context.SaveChangesAsync();
		}

		public async Task RemoveAsync(string bookId, string userId)
		{
			var cart = await context.Carts
				.Include(c => c.CartsBooks)
				.ThenInclude(cb => cb.Book)
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId)));

			var cartBook = cart.CartsBooks
				.First(cb => cb.BookId.Equals(Guid.Parse(bookId)) && !cb.Book.IsDeleted);

			context.CartsBooks.Remove(cartBook);
			await context.SaveChangesAsync();
		}

		public async Task<int> CountAsync(string userId)
		{
			return (await context.Carts
				.AsNoTracking()
				.Include(c => c.CartsBooks)
				.ThenInclude(cb => cb.Book)
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId))))
				.CartsBooks
				.Where(cb => !cb.Book.IsDeleted)
				.Sum(cb => cb.BookCount);
		}
	}
}
