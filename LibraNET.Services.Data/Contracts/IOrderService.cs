using LibraNET.Web.ViewModels.Cart;

namespace LibraNET.Services.Data.Contracts
{
	public interface IOrderService
	{
		Task PlaceOrderAsync(CheckoutViewModel model, string userId);
	}
}
