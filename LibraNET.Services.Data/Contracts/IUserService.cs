﻿using LibraNET.Web.ViewModels.User;

namespace LibraNET.Services.Data.Contracts
{
    public interface IUserService
    {
        Task<ICollection<UserViewModel>> AllAsync(AllUsersViewModel model);
        Task AddCartToUserAsync(string userId);

	}
}
