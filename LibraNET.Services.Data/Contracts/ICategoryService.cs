using LibraNET.Web.ViewModels.Category;

namespace LibraNET.Services.Data.Contracts
{
    public interface ICategoryService
	{
		Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync();
		Task<ICollection<BookCategoryViewModel>> AllForDropdownAsync();
        Task<bool> ExistsByIdAsync(ICollection<string> ids);

    }
}
