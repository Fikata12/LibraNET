using LibraNET.Web.ViewModels.Enums;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.ViewModels
{
	public class AllBooksViewModel
    {
        public AllBooksViewModel()
        {
            CurrentPage = DefaultPage;

			Categories = new List<FiltersCategoryViewModel>();
			Authors = new List<FiltersAuthorViewModel>();

			SelectedAuthorsIds = new List<string>();
			SelectedCategoriesIds = new List<string>();
		}
		public string? SearchString { get; set; }

		public BookSorting BookSorting { get; set; }

		public ICollection<FiltersCategoryViewModel> Categories { get; set; }

		public ICollection<string> SelectedCategoriesIds { get; set; }

		public ICollection<FiltersAuthorViewModel> Authors { get; set; }

		public ICollection<string> SelectedAuthorsIds { get; set; }

		public int SelectedMinPrice { get; set; }

		public int MinPrice { get; set; }

		public int SelectedMaxPrice { get; set; }

        public int MaxPrice { get; set; }

		public int AllBooksCount { get; set; }

        public int CurrentPage { get; set; }

        public IPagedList<BookViewModel> Books { get; set; } = null!;
	}
}
