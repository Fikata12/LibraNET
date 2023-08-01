using LibraNET.Web.ViewModels.User;
using X.PagedList;

namespace LibraNET.Web.ViewModels.Category
{
	public class AllCategoriesViewModel
	{
		public AllCategoriesViewModel()
		{
			CurrentPage = 1;
		}
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		public int AllCategoriesCount { get; set; }

		public IPagedList<CategoryViewModel> Categories { get; set; } = null!;
	}
}
