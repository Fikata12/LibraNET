using LibraNET.Web.ViewModels.Author;

namespace LibraNET.Services.Data.Contracts
{
    public interface IAuthorService
	{
		Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync();
		Task<ICollection<BookAuthorViewModel>> AllForDropdownAsync();
        Task<bool> ExistsByIdAsync(ICollection<string> ids);
    }
}
