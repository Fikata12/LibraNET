using X.PagedList;

namespace LibraNET.Web.ViewModels.User
{
    public class AllUsersViewModel
    {
        public AllUsersViewModel()
        {
            CurrentPage = 1;
        }
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        public int AllUsersCount { get; set; }

        public IPagedList<UserViewModel> Users { get; set; } = null!;
    }
}
