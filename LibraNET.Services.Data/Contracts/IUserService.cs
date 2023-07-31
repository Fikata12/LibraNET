using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels.User;

namespace LibraNET.Services.Data.Contracts
{
    public interface IUserService
    {
        Task<CurrentUsersServiceModel> AllAsync(AllUsersViewModel model);
    }
}
