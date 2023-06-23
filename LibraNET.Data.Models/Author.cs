using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Author;

namespace LibraNET.Data.Models
{
    public class Author
    {
        public Author()
        {
            Id = Guid.NewGuid();
            BooksAuthors = new List<BookAuthor>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLenght)]
        public string FirstName { get; set; } = null!;

        [MaxLength(MiddleNameMaxLenght)]
        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLenght)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageURL { get; set; } = null!;


        public virtual ICollection<BookAuthor> BooksAuthors { get; set; }
    }
}
