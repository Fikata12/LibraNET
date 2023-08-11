using AutoMapper;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class RatingService : IRatingService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public RatingService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		public async Task RateBookAsync(string bookId, string userId, int value)
		{
			var book = await context.Books
				.Where(b => !b.IsDeleted)
				.Include(b => b.Ratings)
				.FirstAsync(b => b.Id.Equals(Guid.Parse(bookId)));

			var rating = book.Ratings
				.FirstOrDefault(r => r.UserId.Equals(Guid.Parse(userId)));

			if (rating == null)
			{
				book.Ratings.Add(new Rating
				{
					UserId = Guid.Parse(userId),
					Value = value
				});

				await context.SaveChangesAsync();

				return;
			}

			rating.Value = value;
			await context.SaveChangesAsync();
		}
	}
}
