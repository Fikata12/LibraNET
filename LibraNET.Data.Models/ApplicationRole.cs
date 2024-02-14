using Microsoft.AspNetCore.Identity;

namespace LibraNET.Data.Models
{
	public class ApplicationRole : IdentityRole<Guid>
	{
		public ApplicationRole()
		{
			UsersRoles = new List<ApplicationUserRole>();
		}
		public virtual ICollection<ApplicationUserRole> UsersRoles { get; set; }
	}
}
