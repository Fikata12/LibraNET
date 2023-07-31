using LibraNET.Web.ViewModels.User;

namespace LibraNET.Services.Data.Models
{
    public class CurrentUsersServiceModel
    {
        public CurrentUsersServiceModel()
        {
            Users = new List<UserViewModel>();
        }

        public int AllUsersCount { get; set; }

        public ICollection<UserViewModel> Users { get; set; }
    }
}
