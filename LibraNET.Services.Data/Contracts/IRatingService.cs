namespace LibraNET.Services.Data.Contracts
{
	public interface IRatingService
	{
		Task RateBookAsync(string bookId, string userId, int value);
	}
}
