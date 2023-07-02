using LibraNET.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants.Order;

namespace LibraNET.Data.Models
{
	public class Order
	{
        public Order()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            OrdersBooks = new List<OrderBook>();
        }

        [Key]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(RecipientNameMaxLength)]
		public string RecipientName { get; set; } = null!;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
        public decimal Price { get; set; }

        [Required]
        public int BookCount { get; set; }

        [Required]
        public DateTime Date { get; set; }

		[Required]
		public OrderStatus Status { get; set; }

		[Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(User))]
		public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual ICollection<OrderBook> OrdersBooks { get; set; }
	}
}
