using LibraNET.Web.ViewModels.User;

namespace LibraNET.Services.Data.Contracts
{
    public interface IUserService
    {
		Task<ICollection<UserViewModel>> AllAsync();
		Task AddCartToUserAsync(string userId);
		Task<AccountViewModel> GetByIdAsync(string userId);
        Task EditAsync(AccountViewModel model, string userId);
	}
}
