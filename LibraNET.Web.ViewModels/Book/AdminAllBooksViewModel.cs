using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.ViewModels.Book
{
    public class AdminAllBooksViewModel
    {
        public AdminAllBooksViewModel()
        {
            CurrentPage = DefaultPage;
        }
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        public IPagedList<AdminBookViewModel> Books { get; set; } = null!;
    }
}
