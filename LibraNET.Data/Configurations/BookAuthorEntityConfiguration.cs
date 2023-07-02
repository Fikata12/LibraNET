using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthor>
	{
		public void Configure(EntityTypeBuilder<BookAuthor> builder)
		{
			builder.HasData(new BookAuthor[]
			{
				new BookAuthor
				{
					BookId = Guid.Parse("234e7f45-82e2-4951-b993-0e0360daff8c"),
					AuthorId = Guid.Parse("7345ddb8-f6da-4f88-aedc-783cee9540ec")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("000"),
					AuthorId = Guid.Parse("000")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("000"),
					AuthorId = Guid.Parse("000")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("000"),
					AuthorId = Guid.Parse("000")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("000"),
					AuthorId = Guid.Parse("000")
				}
			});
		}
	}
}
