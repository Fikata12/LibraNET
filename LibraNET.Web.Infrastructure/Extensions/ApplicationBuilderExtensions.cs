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
        public static IApplicationBuilder SeedAdminRole(this IApplicationBuilder app)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role =
                    new IdentityRole<Guid>(AdminRoleName);

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

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(UserRoleName))
                {
                    return;
                }

                IdentityRole<Guid> role =
                    new IdentityRole<Guid>(UserRoleName);

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

            IUserStore<ApplicationUser> userStore = 
                serviceProvider.GetRequiredService<IUserStore<ApplicationUser>>();
            IUserEmailStore<ApplicationUser> emailStore = 
                (IUserEmailStore<ApplicationUser>)userStore;
            UserManager<ApplicationUser> userManager = 
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            ICartService cartService =
                serviceProvider.GetRequiredService<ICartService>();
            IUserService userService =
                serviceProvider.GetRequiredService<IUserService>();

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
            })
            .GetAwaiter()
            .GetResult();

            return app;
        }
    }
}
