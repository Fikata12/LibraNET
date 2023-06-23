using LibraNET.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants.Book;

namespace LibraNET.Data.Models
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid();
            BooksAuthors = new List<BookAuthor>();
            BooksCategories = new List<BookCategory>();
            Comments = new List<Comment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [MaxLength(ISBNLength)]
        public string? ISBN { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public int PageCount { get; set; }

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        [MaxLength(LanguageMaxLength)]
        public string Language { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }


        public ICollection<BookAuthor> BooksAuthors { get; set; }
        public ICollection<BookCategory> BooksCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Publisher Publisher { get; set; } = null!;
    }
}