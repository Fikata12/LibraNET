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
				.Include(c => c.CartsBooks)
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId)));

			var cartBook = cart.CartsBooks
				.FirstOrDefault(cb => cb.BookId.Equals(Guid.Parse(bookId)));

			if (cartBook == null)
			{
				await context.CartsBooks.AddAsync(new CartBook
				{
					CartId = cart.Id,
					BookId = Guid.Parse(bookId),
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
				.Include(c => c.Book)
				.Where(c => c.Cart.UserId.Equals(Guid.Parse(userId)))
				.ToListAsync());
		}
	}
}
