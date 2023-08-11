using LibraNET.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace LibraNET.Hubs
{
	public class CommentsHub : Hub
	{
		private UserManager<ApplicationUser> userManager;
        public CommentsHub(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SendComment(string comment, string bookId)
		{
			var user = await userManager.GetUserAsync(Context.User);
			var username = $"{user.FirstName} {user.LastName}";
			var dateTime = DateTime.Now.ToString("f");
			comment = WebUtility.HtmlEncode(comment);
			await Clients.All.SendAsync("ReceiveComment", username, comment, dateTime, bookId);
		}
	}
}
