namespace LibraNET.Web.ViewModels.User
{
	public class AdminHomeViewModel
	{
		public int CustomersCount { get; set; }
		public int AdminsCount { get; set; }
		public int SuperAdminsCount { get; set; } 
		public int TotalCount { get; set; }
		public DateTime Updated { get; set; } = DateTime.Now;
	}
}
