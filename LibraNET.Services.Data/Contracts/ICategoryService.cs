using LibraNET.Web.ViewModels.Category;

namespace LibraNET.Services.Data.Contracts
{
    public interface ICategoryService
	{
		Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync();
	}
}
