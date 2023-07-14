using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
	public class CartBook
	{
		[ForeignKey(nameof(Cart))]
		public Guid CartId { get; set; }

		[ForeignKey(nameof(Book))]
		public Guid BookId { get; set; }

		[Required]
		public int BookCount { get; set; } 


		public virtual Cart Cart { get; set; } = null!;
		public virtual Book Book { get; set; } = null!;
	}
}
