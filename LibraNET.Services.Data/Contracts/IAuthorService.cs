using LibraNET.Web.ViewModels.Author;

namespace LibraNET.Services.Data.Contracts
{
    public interface IAuthorService
	{
		Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync();
		Task<ICollection<BookAuthorViewModel>> AllForDropdownAsync();
        Task<bool> ExistsByIdAsync(ICollection<string> ids);
		Task<string> AddAndReturnIdAsync(AuthorFormModel model);
        Task<AuthorFormModel> GetByIdAsync(string id);
        Task<string> EditAndReturnIdAsync(AuthorFormModel model, string id);
        Task<string?> GetImageIdAsync(string id);

    }
}
