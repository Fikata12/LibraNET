namespace LibraNET.Web.ViewModels.Comment
{
	public class CommentViewModel
	{
		public string Id { get; set; } = null!;

		public string Text { get; set; } = null!;

		public DateTime SubmissionTime { get; set; }

		public string Name { get; set; } = null!;
	}
}