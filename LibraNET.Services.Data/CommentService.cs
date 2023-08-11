using AutoMapper;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data
{
	public class CommentService : ICommentService
	{
		private readonly LibraNetDbContext context;
		private readonly IMapper mapper;

		public CommentService(LibraNetDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		public async Task AddComment(string bookId, string userId, string text)
		{
			var book = await context.Books
				.Where(b => !b.IsDeleted)
				.Include(b => b.Comments)
				.FirstAsync(b => b.Id.Equals(Guid.Parse(bookId)));

			await context.Comments.AddAsync(new Comment
			{
				Book = book,
				UserId = Guid.Parse(userId),
				Text = text
			});

			await context.SaveChangesAsync();
		}
	}
}
