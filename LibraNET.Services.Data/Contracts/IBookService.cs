﻿using LibraNET.Web.ViewModels.Book;

namespace LibraNET.Services.Data.Contracts
{
	public interface IBookService
	{
		Task<ICollection<BookViewModel>> LastThreeBooksAsync();
		Task<ICollection<BookViewModel>> AllAsync(AllBooksViewModel model);
		Task<ICollection<AdminBookViewModel>> AllAsync(AdminAllBooksViewModel model);
        Task<decimal> MinPriceAsync();
		Task<decimal> MaxPriceAsync();
		Task<string> AddAndReturnIdAsync(BookFormModel model);
		Task<BookFormModel> GetByIdAsync(string id);
		Task EditAsync(BookFormModel model, string id);
		Task<string> GetImageIdAsync(string bookId);
		Task DeleteAsync(string id);
		Task<bool> ExistsByIdAsync(string id);
		Task<bool> ExistsByIsbnAsync(string ISBN);
		Task<BookDetailsViewModel> GetByIdAsync(string bookId, string userId);
		Task<int> AvailableCountAsync(string id);
		Task ToggleFavoriteAsync(string bookId, string userId);
		Task<ICollection<BookViewModel>> AllFavoritesAsync(FavoriteViewModel model, string userId);
		Task<int> CommentsCountAsync(string bookId);
		Task<bool> IsbnBelongsToIdAsync(string isbn, string id);
	}
}
