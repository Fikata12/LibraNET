using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Models
{
    public class CurrentBooksServiceModel
	{
		public CurrentBooksServiceModel()
		{
			Books = new List<BookViewModel>();
		}

		public int AllBooksCount { get; set; }

		public ICollection<BookViewModel> Books { get; set; }
	}
}