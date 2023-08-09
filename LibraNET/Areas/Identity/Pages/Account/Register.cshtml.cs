// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using static LibraNET.Common.ValidationConstants.ApplicationUser;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;
		private readonly IUserStore<ApplicationUser> userStore;
		private readonly IUserEmailStore<ApplicationUser> emailStore;
		private readonly ILogger<RegisterModel> logger;
		private readonly IEmailSender emailSender;
		private readonly ICartService cartService;
		private readonly IUserService userService;

		public RegisterModel(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole<Guid>> roleManager,
			IUserStore<ApplicationUser> userStore,
			SignInManager<ApplicationUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender,
			ICartService cartService,
			IUserService userService)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.userStore = userStore;
			emailStore = GetEmailStore();
			this.signInManager = signInManager;
			this.logger = logger;
			this.emailSender = emailSender;
			this.cartService = cartService;
			this.userService = userService;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			[Required]
			[Display(Name = "First Name")]
			[StringLength(FirstNameMaxLength,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
				MinimumLength = FirstNameMinLength)]
			public string FirstName { get; set; }

			[Required]
			[Display(Name = "Last Name")]
			[StringLength(LastNameMaxLength,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
				MinimumLength = LastNameMinLength)]
			public string LastName { get; set; }

			[Required]
			[Display(Name = "Phone Number")]
			[StringLength(PhoneNumberMaxLength,
				ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
				MinimumLength = PhoneNumberMinLength)]
			[RegularExpression(PhoneNumberRegex,
				ErrorMessage = "Enter a valid Phone Number.")]
			public string PhoneNumber { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}


		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");
			ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if (ModelState.IsValid)
			{
				var user = CreateUser();

				user.FirstName = Input.FirstName;
				user.LastName = Input.LastName;
				user.PhoneNumber = Input.PhoneNumber;

				await userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
				await emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
				var result = await userManager.CreateAsync(user, Input.Password);

				if (result.Succeeded)
				{
					logger.LogInformation("User created a new account with password.");

					var userId = await userManager.GetUserIdAsync(user);

					await cartService.AddCartAsync(userId);
					await userService.AddCartToUserAsync(userId);

					bool roleExists = await roleManager.RoleExistsAsync(UserRoleName);

					if (roleExists)
					{
						await userManager.AddToRoleAsync(user, UserRoleName);
					}

					var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					await emailSender.SendEmailAsync(Input.Email, "Confirm your email",
						$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

					if (userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
					}
					else
					{
						await signInManager.SignInAsync(user, isPersistent: false);
						return LocalRedirect(returnUrl);
					}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}

		private ApplicationUser CreateUser()
		{
			try
			{
				return Activator.CreateInstance<ApplicationUser>();
			}
			catch
			{
				throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
					$"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
					$"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
			}
		}

		private IUserEmailStore<ApplicationUser> GetEmailStore()
		{
			if (!userManager.SupportsUserEmail)
			{
				throw new NotSupportedException("The default UI requires a user store with email support.");
			}
			return (IUserEmailStore<ApplicationUser>)userStore;
		}
	}
}
