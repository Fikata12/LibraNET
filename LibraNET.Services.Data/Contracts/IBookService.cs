using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Contracts
{
	public interface IBookService
	{
		Task<ICollection<BookIndexViewModel>> GetNewestBooks();
	}
}
