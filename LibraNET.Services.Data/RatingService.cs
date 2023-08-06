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
			var rating = await context.Ratings
				.FirstOrDefaultAsync(r => r.BookId.Equals(Guid.Parse(bookId)) && r.UserId.Equals(Guid.Parse(userId)));

			if (rating == null)
			{
				await context.Ratings.AddAsync(new Rating
				{
					BookId = Guid.Parse(bookId),
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
