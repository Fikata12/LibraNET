using LibraNET.Data.Models.Enums;
using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Web.ViewModels.Order
{
    public class OrderDetailsViewModel
	{
        public OrderDetailsViewModel()
        {
            Books = new List<BookOrderViewModel>();
        }
        public string Id { get; set; } = null!;

		public string RecipientName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string Town { get; set; } = null!;

		public string PostCode { get; set; } = null!;

		public string Address { get; set; } = null!;

		public DateTime Date { get; set; }

		public OrderStatus Status { get; set; }

		public int NewOrderStatus { get; set; }

		public ICollection<BookOrderViewModel> Books { get; set; }
	}
}
