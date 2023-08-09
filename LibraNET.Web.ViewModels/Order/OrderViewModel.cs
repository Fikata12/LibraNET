using LibraNET.Web.ViewModels.Book;
using System.ComponentModel.DataAnnotations;

namespace LibraNET.Web.ViewModels.Order
{
	public class OrderViewModel
	{
        public OrderViewModel()
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

		public string Status { get; set; } = null!;

		public ICollection<BookOrderViewModel> Books { get; set; }
	}
}
