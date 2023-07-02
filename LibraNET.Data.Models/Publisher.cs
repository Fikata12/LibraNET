using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Publisher;

namespace LibraNET.Data.Models
{
    public class Publisher
    {
        public Publisher()
        {
            Id = Guid.NewGuid();
            Books = new List<Book>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public string? WebsiteURL { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}
