using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Category;

namespace LibraNET.Web.ViewModels.Book
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Authors = new List<BookAuthorViewModel>();
            Categories = new List<BookCategoryViewModel>();
        }
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageId { get; set; } = null!;

        public IList<BookAuthorViewModel> Authors { get; set; }

        public IList<BookCategoryViewModel> Categories { get; set; }
    }
}
