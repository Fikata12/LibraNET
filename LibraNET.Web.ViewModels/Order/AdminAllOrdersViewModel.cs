using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;

namespace LibraNET.Web.ViewModels.Order
{
    public class AdminAllOrdersViewModel
    {
        public AdminAllOrdersViewModel()
        {
            CurrentPage = DefaultPage;
        }
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        public IPagedList<AdminOrderViewModel> Orders { get; set; } = null!;
    }
}
