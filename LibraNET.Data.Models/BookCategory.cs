using System.ComponentModel.DataAnnotations.Schema;

namespace LibraNET.Data.Models
{
    public class BookCategory
    {
        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }


        public virtual Book Book { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
