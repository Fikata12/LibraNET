using LibraNET.Data.Models.Enums;

namespace LibraNET.Web.ViewModels.Order
{
    public class AdminOrderViewModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Date { get; set; } = null!;

        public OrderStatus Status { get; set; }
    }
}
