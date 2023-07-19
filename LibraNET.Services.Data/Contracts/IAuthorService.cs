using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Data.Contracts
{
	public interface IAuthorService
	{
		Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync();
	}
}
