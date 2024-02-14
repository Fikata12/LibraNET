using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants.ApplicationUser;

namespace LibraNET.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
        public ApplicationUser()
        {
			UsersFavouriteBooks = new List<UserFavouriteBook>();
			Comments = new List<Comment>();
			Ratings = new List<Rating>();
			Orders = new List<Order>();
			UsersRoles = new List<ApplicationUserRole>();
		}

		[MaxLength(FirstNameMaxLength)]
		public string? FirstName { get; set; }

		[MaxLength(LastNameMaxLength)]
		public string? LastName { get; set; }

        [MaxLength(PhoneNumberMaxLength)]
        public override string? PhoneNumber { get; set; }

        [ForeignKey(nameof(Cart))]
		public Guid? CartId { get; set; }

		public virtual Cart Cart { get; set; } = null!;
		public virtual ICollection<UserFavouriteBook> UsersFavouriteBooks { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
		public virtual ICollection<Rating> Ratings { get; set; }	
		public virtual ICollection<ApplicationUserRole> UsersRoles { get; set; }
	}
}
