using LibraNET.Web.ViewModels.Author;

namespace LibraNET.Services.Data.Contracts
{
    public interface IAuthorService
	{
		Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync();
		Task<ICollection<BookAuthorViewModel>> AllForDropdownAsync();
        Task<bool> ExistsByIdAsync(ICollection<string> ids);
		Task<bool> ExistsByIdAsync(string id);
		Task<bool> ExistsByNameAsync(string name);
		Task<string> AddAndReturnIdAsync(AuthorFormModel model);
        Task<AuthorFormModel> GetByIdAsync(string id);
        Task<string> EditAndReturnIdAsync(AuthorFormModel model, string id);
        Task<string?> GetImageIdAsync(string id);
		Task<ICollection<AuthorViewModel>> AllAsync(AllAuthorsViewModel model);
		Task DeleteAsync(string id);
		Task<AuthorDetailsViewModel> GetDetailsAsync(string id);
	}
}
