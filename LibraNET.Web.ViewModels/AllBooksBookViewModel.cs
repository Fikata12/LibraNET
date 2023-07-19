namespace LibraNET.Web.ViewModels
{
    public class AllBooksBookViewModel
    {
        public AllBooksBookViewModel()
        {
            Authors = new List<AllBooksAuthorViewModel>();
            Categories = new List<AllBooksCategoryViewModel>();
        }
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

		public string ImageId { get; set; } = null!;

		public IList<AllBooksAuthorViewModel> Authors { get; set; }

		public IList<AllBooksCategoryViewModel> Categories { get; set; }
	}
}
