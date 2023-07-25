using LibraNET.Services.Data.Models;
using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Contracts
{
    public interface IBookService
	{
		Task<ICollection<BookViewModel>> LastThreeBooksAsync();
		Task<CurrentBooksServiceModel> AllAsync(AllBooksViewModel model);
		Task<decimal> MinPriceAsync();
		Task<decimal> MaxPriceAsync();
		Task<string> AddAndReturnIdAsync(BookFormModel model);
    }
}
