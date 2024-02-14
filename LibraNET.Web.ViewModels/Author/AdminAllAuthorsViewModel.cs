using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.ViewModels.Author
{
    public class AdminAllAuthorsViewModel
    {
        public AdminAllAuthorsViewModel()
        {
            CurrentPage = DefaultPage;
        }
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        public IPagedList<AdminAuthorViewModel> Authors { get; set; } = null!;
    }
}
