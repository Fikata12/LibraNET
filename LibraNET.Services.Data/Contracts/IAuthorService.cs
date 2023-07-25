using LibraNET.Web.ViewModels.Author;

namespace LibraNET.Services.Data.Contracts
{
    public interface IAuthorService
	{
		Task<ICollection<FiltersAuthorViewModel>> AllForFiltersAsync();
	}
}
