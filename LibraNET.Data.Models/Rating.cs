using Microsoft.AspNetCore.Identity;
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
        [ForeignKey(nameof(Rater))]
        public string RaterId { get; set; } = null!;

        [Required]
        public int Value { get; set; }


        public virtual IdentityUser Rater { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}