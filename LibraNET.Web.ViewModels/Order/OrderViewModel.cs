using LibraNET.Data.Models.Enums;

namespace LibraNET.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Id { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Date { get; set; } = null!;
        public OrderStatus Status { get; set; }
    }
}
