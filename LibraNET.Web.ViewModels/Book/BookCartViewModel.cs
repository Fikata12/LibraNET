namespace LibraNET.Web.ViewModels.Book
{
	public class BookCartViewModel
	{
		public string Id { get; set; } = null!;

		public string Title { get; set; } = null!;

		public string ImageId { get; set; } = null!;

		public int Quantity { get; set; }

		public decimal TotalPrice { get; set; }

		public int AvailableCount { get; set; }
	}
}
