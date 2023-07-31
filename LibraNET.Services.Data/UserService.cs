using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
    public class UserService : IUserService
    {
        private readonly LibraNetDbContext context;
        private readonly IMapper mapper;

        public UserService(LibraNetDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<CurrentUsersServiceModel> AllAsync(AllUsersViewModel model)
        {
            var usersQuery = context.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(model.SearchString))
            {
                string wildCard = $"%{model.SearchString}%";

                usersQuery = usersQuery.Where(u => EF.Functions.Like(u.Email, wildCard) ||
                                                   EF.Functions.Like(u.Id.ToString(), wildCard));
            }

            ICollection<UserViewModel> users = await usersQuery
                .Where(u => u.UserName != null)
                .ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            int allUsersCount = usersQuery.Count();

            return new CurrentUsersServiceModel
            {
                Users = users,
                AllUsersCount = allUsersCount
            };
        }
    }
}
