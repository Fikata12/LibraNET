using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Data.Models.Enums;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Cart;
using LibraNET.Web.ViewModels.Order;
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
                .Where(cb => cb.Cart.UserId.Equals(Guid.Parse(userId)) && !cb.Book.IsDeleted)
                .ProjectTo<OrderBook>(mapper.ConfigurationProvider)
                .ToListAsync();

            var cartBooks = await context.CartsBooks
                .Include(cb => cb.Book)
                .Where(cb => cb.Cart.UserId.Equals(Guid.Parse(userId)))
                .ToListAsync();

            cartBooks.ForEach(cb => cb.Book.AvailableCount -= cb.BookCount);

            context.CartsBooks.RemoveRange(cartBooks);

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<AdminOrderViewModel>> AllAsync(AdminAllOrdersViewModel model)
        {
            var ordersQuery = context.Orders.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                string wildCard = $"%{model.SearchString}%";

                ordersQuery = ordersQuery.Where(o => EF.Functions.Like(o.Id.ToString(), wildCard) ||
                                            EF.Functions.Like(o.User.Email, wildCard) ||
                                            (o.Status == OrderStatus.Placed && EF.Functions.Like("Placed", wildCard)) ||
                                            (o.Status == OrderStatus.Processing && EF.Functions.Like("Processing", wildCard)) ||
                                            (o.Status == OrderStatus.Shipping && EF.Functions.Like("Shipping", wildCard)) ||
                                            (o.Status == OrderStatus.Delivered && EF.Functions.Like("Delivered", wildCard)) ||
                                            (o.Status == OrderStatus.Cancelled && EF.Functions.Like("Cancelled", wildCard)));
            }

            ICollection<AdminOrderViewModel> orders = await ordersQuery
                .OrderBy(o => o.Status)
                .ThenBy(o => o.Date)
                .ProjectTo<AdminOrderViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return orders;
        }

        public async Task<bool> IsOwner(string userId, string orderId)
        {
            return (await context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.UserId.ToString() == userId && o.Id.ToString() == orderId)) != null;
        }

        public async Task<OrderDetailsViewModel> GetByIdAsync(string id)
        {
            return mapper.Map<OrderDetailsViewModel>(await context.Orders
                .AsNoTracking()
				.Include(o => o.OrdersBooks)
				.ThenInclude(ob => ob.Book)
				.FirstOrDefaultAsync(o => o.Id.ToString() == id));
        }

        public async Task ChangeStatusAsync(string id, int newStatus)
        {
            var order = await context.Orders
                .FirstOrDefaultAsync(o => o.Id.ToString() == id);

            if (order != null)
            {
                order.Status = (OrderStatus)newStatus;
                await context.SaveChangesAsync();
            }
        }
    }
}
