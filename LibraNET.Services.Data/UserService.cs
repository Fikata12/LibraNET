using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraNET.Data;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using static LibraNET.Common.GeneralApplicationConstants;

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
		public async Task<ICollection<UserViewModel>> AllAsync()
		{
			return await context.Users
				.AsNoTracking()
				.Where(u => u.UserName != null)
				.ProjectTo<UserViewModel>(mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task AddCartToUserAsync(string userId)
		{
			var user = await context.Users
				.FirstAsync(u => u.Id.Equals(Guid.Parse(userId)));

			user.CartId = (await context.Carts
				.FirstAsync(c => c.UserId.Equals(Guid.Parse(userId)))).Id;

			await context.SaveChangesAsync();
		}

		public async Task<AccountViewModel> GetByIdAsync(string userId)
		{
			var user = await context.Users
				.Include(u => u.Orders)
				.ThenInclude(o => o.OrdersBooks)
				.ThenInclude(ob => ob.Book)
				.FirstAsync(u => u.Id.Equals(Guid.Parse(userId)));

			return mapper.Map<AccountViewModel>(user);
		}

		public async Task EditAsync(AccountViewModel model, string userId)
		{
			var user = await context.Users
				.FirstAsync(u => u.Id.Equals(Guid.Parse(userId)));

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.PhoneNumber = model.PhoneNumber;

			await context.SaveChangesAsync();
		}

		public async Task<int> CustomersCountAsync()
		{
			return await context.Users
				.AsNoTracking()
				.Where(u => u.UsersRoles.Count == 0)
				.CountAsync();
		}

		public async Task<int> AdminsCountAsync()
		{
			return await context.Users
				.AsNoTracking()
				.Where(u => u.UsersRoles.Any(ur => ur.Role.Name == AdminRoleName))
				.CountAsync();
		}

		public async Task<int> SuperAdminsCountAsync()
		{
			return await context.Users
				.AsNoTracking()
				.Where(u => u.UsersRoles.Any(ur => ur.Role.Name == SuperAdminRoleName))
				.CountAsync();
		}
        public async Task<int> CountAsync()
        {
            return await context.Users
                .AsNoTracking()
                .CountAsync();
        }
    }
}
