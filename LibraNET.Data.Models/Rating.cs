using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraNET.Data.Models
{
	public class Rating
    {
        [Required]
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public int Value { get; set; }


        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}