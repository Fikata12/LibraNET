using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants;
using static LibraNET.Common.ValidationConstants.Address;

namespace LibraNET.Data.Models
{
	public class Address
	{
        public Address()
		{
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        public string Town { get; set; } = null!;

        [Required]
        [MaxLength(PostCodeLength)]
        public string PostCode { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
		public string StreetAddress { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
	}
}