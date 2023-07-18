using LibraNET.Web.ViewModels.Enums;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.ViewModels
{
	public class AllBooksViewModel
    {
        public AllBooksViewModel()
        {
            CurrentPage = DefaultPage;
			this.BooksPerPage = EntitiesPerPage;

            ChosenCategories = new List<CategoryViewModel>();
            ChosenAuthors = new List<AllBooksAuthorViewModel>();

			Categories = new List<CategoryViewModel>();
			Authors = new List<AllBooksAuthorViewModel>();
			Books = new List<AllBooksBookViewModel>();
		}
		public string? SearchString { get; set; }

        public BookSorting? BookSorting { get; set; }

		public ICollection<CategoryViewModel> ChosenCategories { get; set; }

		public ICollection<CategoryViewModel> Categories { get; set; }

		public ICollection<AllBooksAuthorViewModel> ChosenAuthors { get; set; }

		public ICollection<AllBooksAuthorViewModel> Authors { get; set; }

		public int ChosenMinPrice { get; set; }

		public int MinPrice { get; set; }

		public int ChosenMaxPrice { get; set; }

        public int MaxPrice { get; set; }

		public int AllBooksCount { get; set; }

        public int CurrentPage { get; set; }

        public int BooksPerPage { get; set; }

        public ICollection<AllBooksBookViewModel> Books { get; set; }
	}
}
