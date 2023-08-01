using LibraNET.Web.ViewModels.Category;
using X.PagedList;

namespace LibraNET.Web.ViewModels.Author
{
	public class AllAuthorsViewModel
	{
		public AllAuthorsViewModel()
		{
			CurrentPage = 1;
		}
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		public int AllAuthorsCount { get; set; }

		public IPagedList<AuthorViewModel> Authors { get; set; } = null!;
	}
}
