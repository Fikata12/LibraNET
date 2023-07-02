using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
    public class UserFavouriteBook
    {
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
