using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
    public class BookAuthor
    {
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }


        public virtual Book Book { get; set; } = null!;
        public virtual Author Author { get; set; } = null!;
    }
}
