using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
		public static IApplicationBuilder SeedSuperAdminRole(this IApplicationBuilder app)
		{
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			RoleManager<ApplicationRole> roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(SuperAdminRoleName))
				{
					return;
				}

				ApplicationRole role = new ApplicationRole();
                role.Name = SuperAdminRoleName;

				await roleManager.CreateAsync(role);
			})
			.GetAwaiter()
			.GetResult();

			return app;
		}
		public static IApplicationBuilder SeedAdminRole(this IApplicationBuilder app)
        {
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			RoleManager<ApplicationRole> roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(AdminRoleName))
				{
					return;
				}

				ApplicationRole role = new ApplicationRole();
				role.Name = AdminRoleName;

				await roleManager.CreateAsync(role);
			})
			.GetAwaiter()
			.GetResult();

			return app;
		}
        public static IApplicationBuilder SeedUserRole(this IApplicationBuilder app)
        {
			using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

			IServiceProvider serviceProvider = scopedServices.ServiceProvider;

			RoleManager<ApplicationRole> roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			Task.Run(async () =>
			{
				if (await roleManager.RoleExistsAsync(UserRoleName))
				{
					return;
				}

				ApplicationRole role = new ApplicationRole();
				role.Name = UserRoleName;

				await roleManager.CreateAsync(role);
			})
			.GetAwaiter()
			.GetResult();

			return app;
		}
        public static IApplicationBuilder SeedUsers(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            IUserStore<ApplicationUser> userStore = serviceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
            IUserEmailStore<ApplicationUser> emailStore = (IUserEmailStore<ApplicationUser>)userStore;
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ICartService cartService = serviceProvider.GetRequiredService<ICartService>();
            IUserService userService = serviceProvider.GetRequiredService<IUserService>();

            Task.Run(async () =>
            {
                if (await userManager.FindByEmailAsync(UserEmail) == null)
                {
                    var user = new ApplicationUser();

                    user.FirstName = UserFirstName;
                    user.LastName = UserLastName;
                    user.PhoneNumber = UserPhoneNumber;

                    await userStore.SetUserNameAsync(user, UserEmail, CancellationToken.None);
                    await emailStore.SetEmailAsync(user, UserEmail, CancellationToken.None);
                    await userManager.CreateAsync(user, UserPassword);
                    await cartService.AddCartAsync(user.Id.ToString());
                    await userService.AddCartToUserAsync(user.Id.ToString());
                }

                if (await userManager.FindByEmailAsync(AdminEmail) == null)
                {
                    var admin = new ApplicationUser();

                    admin.FirstName = AdminFirstName;
                    admin.LastName = AdminLastName;
                    admin.PhoneNumber = AdminPhoneNumber;

                    await userStore.SetUserNameAsync(admin, AdminEmail, CancellationToken.None);
                    await emailStore.SetEmailAsync(admin, AdminEmail, CancellationToken.None);
                    await userManager.CreateAsync(admin, AdminPassword);
                    await userManager.AddToRoleAsync(admin, AdminRoleName);
                    await cartService.AddCartAsync(admin.Id.ToString());
                    await userService.AddCartToUserAsync(admin.Id.ToString());
                }

				if (await userManager.FindByEmailAsync(SuperAdminEmail) == null)
				{
					var superAdmin = new ApplicationUser();

					superAdmin.FirstName = SuperAdminFirstName;
					superAdmin.LastName = SuperAdminLastName;
					superAdmin.PhoneNumber = SuperAdminPhoneNumber;

					await userStore.SetUserNameAsync(superAdmin, SuperAdminEmail, CancellationToken.None);
					await emailStore.SetEmailAsync(superAdmin, SuperAdminEmail, CancellationToken.None);
					await userManager.CreateAsync(superAdmin, SuperAdminPassword);
					await userManager.AddToRoleAsync(superAdmin, SuperAdminRoleName);
					await cartService.AddCartAsync(superAdmin.Id.ToString());
					await userService.AddCartToUserAsync(superAdmin.Id.ToString());
				}
			})
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
