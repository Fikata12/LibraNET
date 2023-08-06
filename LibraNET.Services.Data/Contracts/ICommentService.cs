namespace LibraNET.Services.Data.Contracts
{
	public interface ICommentService
	{
		Task AddComment(string bookId, string userId, string comment);
	}
}
