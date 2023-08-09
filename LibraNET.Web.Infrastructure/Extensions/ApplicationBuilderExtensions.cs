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
	}
}
