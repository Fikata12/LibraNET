using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Cart;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class OrderService : IOrderService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public OrderService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task PlaceOrderAsync(CheckoutViewModel model, string userId)
		{
			var order = mapper.Map<Order>(model, opt => opt.Items["UserId"] = userId);

			order.OrdersBooks = await context.CartsBooks
				.Where(cb => cb.Cart.UserId.Equals(Guid.Parse(userId)))
				.ProjectTo<OrderBook>(mapper.ConfigurationProvider)
				.ToListAsync();

			var cartBooks = await context.CartsBooks.ToListAsync();
			context.CartsBooks.RemoveRange(cartBooks);

			await context.Orders.AddAsync(order);
			await context.SaveChangesAsync();
		}
	}
}
