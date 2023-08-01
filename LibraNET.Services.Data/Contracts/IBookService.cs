using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Contracts
{
    public interface IBookService
	{
		Task<ICollection<BookViewModel>> LastThreeBooksAsync();
		Task<ICollection<BookViewModel>> AllAsync(AllBooksViewModel model);
        Task<decimal> MinPriceAsync();
		Task<decimal> MaxPriceAsync();
		Task<string> AddAndReturnIdAsync(BookFormModel model);
		Task<BookFormModel> GetByIdAsync(string id);
		Task<string> EditAndReturnIdAsync(BookFormModel model, string id);
		Task<string?> GetImageIdAsync(string bookId);
		Task DeleteAsync(string id);
		Task<bool> ExistsByIdAsync(string id);
	}
}
