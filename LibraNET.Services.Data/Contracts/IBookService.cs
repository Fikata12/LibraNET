using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Data.Contracts
{
    public interface IBookService
	{
		Task<ICollection<HomeBookViewModel>> LastThreeBooks();
	}
}
