using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
	public class ApplicationUserRole : IdentityUserRole<Guid>
	{
		public virtual ApplicationUser User { get; set; } = null!;
		public virtual ApplicationRole Role { get; set; } = null!;
	}
}
