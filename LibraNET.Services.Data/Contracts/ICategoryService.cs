using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Data.Contracts
{
	public interface ICategoryService
	{
		Task<ICollection<FiltersCategoryViewModel>> AllForFiltersAsync();
	}
}
