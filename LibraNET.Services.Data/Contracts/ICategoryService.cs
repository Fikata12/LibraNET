using LibraNET.Web.ViewModels.Category;

namespace LibraNET.Services.Data.Contracts
{
    public interface ICategoryService
	{
		Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync();
		Task<ICollection<CategoryViewModel>> AllForDropdownAsync();
        Task<bool> ExistsByIdAsync(ICollection<string> ids);
		Task<bool> ExistsByIdAsync(string id);
		Task<bool> ExistsByNameAsync(string name);
		Task AddAsync(CategoryFormModel model);
        Task<CategoryFormModel> GetByIdAsync(string id);
        Task EditAsync(CategoryFormModel model, string id);
		Task<ICollection<CategoryViewModel>> AllAsync(AllCategoriesViewModel model);
		Task DeleteAsync(string id);
	}
}
