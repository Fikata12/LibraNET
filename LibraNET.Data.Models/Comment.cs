using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants.Comment;

namespace LibraNET.Data.Models
{
	public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid();
            SubmissionTime = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }


        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
