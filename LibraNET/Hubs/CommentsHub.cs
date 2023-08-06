using LibraNET.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace LibraNET.Hubs
{
	public class CommentsHub : Hub
	{
		private UserManager<ApplicationUser> userManager;
        public CommentsHub(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SendComment(string comment)
		{
			var user = await userManager.GetUserAsync(Context.User);
			var username = $"{user.FirstName} {user.LastName}";
			var dateTime = DateTime.Now.ToString("f");
			await Clients.All.SendAsync("ReceiveComment", username, comment, dateTime);
		}
	}
}
