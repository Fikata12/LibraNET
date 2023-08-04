using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraNET.Web.ViewModels.Comment
{
    public class CommentViewModel
    {
		public string Id { get; set; } = null!;

		public string Text { get; set; } = null!;

		public DateTime SubmissionTime { get; set; }

		public string Username { get; set; } = null!;
	}
}