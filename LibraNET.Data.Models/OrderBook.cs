using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraNET.Data.Models
{
	public class OrderBook
	{
		[ForeignKey(nameof(Order))]
		public Guid OrderId { get; set; }

		[ForeignKey(nameof(Book))]
		public Guid BookId { get; set; }

		[Required]
		public int BookCount { get; set; }


		public virtual Order Order { get; set; } = null!;
		public virtual Book Book { get; set; } = null!;
	}
}
