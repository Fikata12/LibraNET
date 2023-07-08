namespace LibraNET.Web.ViewModels.Book
{
	public class BookIndexViewModel
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string ImageId { get; set; } = null!;
	}
}
