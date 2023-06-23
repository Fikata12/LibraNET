using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraNET.Data.Models
{
    public class Rating
    {
        public Rating()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        [ForeignKey(nameof(Rater))]
        public Guid RaterId { get; set; }

        [Required]
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }


        public virtual IdentityUser Rater { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
