using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
	public class Cart
	{
        public Cart()
        {
            Id = Guid.NewGuid();
            CartsBooks = new List<CartBook>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int BookCount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }


        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<CartBook> CartsBooks { get; set; }
	}
}