using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class BookCategoryEntityConfiguration : IEntityTypeConfiguration<BookCategory>
	{
		public void Configure(EntityTypeBuilder<BookCategory> builder)
		{
			builder.HasData(new BookCategory[]
			{
				new BookCategory
				{
					BookId = Guid.Parse("234e7f45-82e2-4951-b993-0e0360daff8c"),
					CategoryId = Guid.Parse("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed")
				},
				new BookCategory
				{
					BookId = Guid.Parse("000"),
					CategoryId = Guid.Parse("000")
				},
				new BookCategory
				{
					BookId = Guid.Parse("000"),
					CategoryId = Guid.Parse("000")
				},
				new BookCategory
				{
					BookId = Guid.Parse("000"),
					CategoryId = Guid.Parse("000")
				},
				new BookCategory
				{
					BookId = Guid.Parse("000"),
					CategoryId = Guid.Parse("000")
				},
			});
		}
	}
}
