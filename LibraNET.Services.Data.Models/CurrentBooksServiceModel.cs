using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Data.Models
{
	public class CurrentBooksServiceModel
	{
		public CurrentBooksServiceModel()
		{
			Books = new List<AllBooksBookViewModel>();
		}

		public int AllBooksCount { get; set; }

		public ICollection<AllBooksBookViewModel> Books { get; set; }
	}
}