using LibraNET.Web.ViewModels.Cart;
using LibraNET.Web.ViewModels.Order;

namespace LibraNET.Services.Data.Contracts
{
	public interface IOrderService
	{
		Task PlaceOrderAsync(CheckoutViewModel model, string userId);
		Task<ICollection<AdminOrderViewModel>> AllAsync(AdminAllOrdersViewModel model);
        Task<bool> IsOwner(string userId, string orderId);
        Task<OrderDetailsViewModel> GetByIdAsync(string id);
        Task ChangeStatusAsync(string id, int newStatus);
    }
}
