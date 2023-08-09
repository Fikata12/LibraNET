using X.PagedList;

namespace LibraNET.Web.ViewModels.Book
{
	public class FavoriteViewModel
    {
        public FavoriteViewModel()
        {
            CurrentPage = 1;
        }
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        public int AllBooksCount { get; set; }

        public IPagedList<BookViewModel> Books { get; set; } = null!;
    }
}
