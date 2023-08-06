using AutoMapper;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Contracts;

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
			await context.Comments.AddAsync(new Comment
			{
				BookId = Guid.Parse(bookId),
				UserId = Guid.Parse(userId),
				Text = text
			});

			await context.SaveChangesAsync();
		}
	}
}
