using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Contracts
{
	public interface ICartService
	{
		Task AddAsync(string bookId, string userId, int quantity);
		Task<ICollection<BookCartViewModel>> GetCartAsync(string userId);
		Task AddCartAsync(string userId);
		Task ChangeQuantityAsync(string bookId, string userId, int quantity);
		Task RemoveAsync(string bookId, string userId);
		Task<int> CountAsync(string userId);
	}
}
