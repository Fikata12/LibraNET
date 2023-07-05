using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class BookCategoryEntityConfiguration : IEntityTypeConfiguration<BookCategory>
	{
		public void Configure(EntityTypeBuilder<BookCategory> builder)
		{
			builder.HasKey(e => new { e.BookId, e.CategoryId });

			builder.HasData(new BookCategory[]
			{
				new BookCategory
				{
					BookId = Guid.Parse("234e7f45-82e2-4951-b993-0e0360daff8c"),
					CategoryId = Guid.Parse("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed")
				},
				new BookCategory
				{
					BookId = Guid.Parse("ee5aea48-22b6-44bc-bfee-309290f19c35"),
					CategoryId = Guid.Parse("03f32211-7021-4b30-863d-e81a2766623e")
				},
				new BookCategory
				{
					BookId = Guid.Parse("5f619a68-3e7f-448e-b352-717915da20e5"),
					CategoryId = Guid.Parse("1dd3c6f1-da15-421e-90a7-d8cbb8449371")
				},
				new BookCategory
				{
					BookId = Guid.Parse("cd6c5819-53e3-4024-9216-ae0f6502996d"),
					CategoryId = Guid.Parse("c577d932-8104-4903-95f3-23d6ab5a25f0")
				},
				new BookCategory
				{
					BookId = Guid.Parse("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
					CategoryId = Guid.Parse("016437a5-5135-43d3-850d-99e150d64e61")
				},
				new BookCategory
				{
					BookId = Guid.Parse("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
					CategoryId = Guid.Parse("161ec94a-5eca-4fdf-8dd6-485675b4b624")
				},
				new BookCategory
				{
					BookId = Guid.Parse("be157e3e-161f-4764-a782-2bec929bcd94"),
					CategoryId = Guid.Parse("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a")
				},
				new BookCategory
				{
					BookId = Guid.Parse("5d437d09-15fd-4969-856d-6694f1d75f5f"),
					CategoryId = Guid.Parse("b15c4a7f-0b30-4fdf-b664-991785501402")
				},
				new BookCategory
				{
					BookId = Guid.Parse("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
					CategoryId = Guid.Parse("03f32211-7021-4b30-863d-e81a2766623e")
				},
				new BookCategory
				{
					BookId = Guid.Parse("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
					CategoryId = Guid.Parse("03f32211-7021-4b30-863d-e81a2766623e")
				},
				new BookCategory
				{
					BookId = Guid.Parse("c482f838-87c4-4443-b143-62637d4f97e7"),
					CategoryId = Guid.Parse("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e")
				},
                new BookCategory
                {
                    BookId = Guid.Parse("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                    CategoryId = Guid.Parse("b15c4a7f-0b30-4fdf-b664-991785501402")
                },
                new BookCategory
                {
                    BookId = Guid.Parse("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                    CategoryId = Guid.Parse("b15c4a7f-0b30-4fdf-b664-991785501402")
                },
                new BookCategory
                {
                    BookId = Guid.Parse("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                    CategoryId = Guid.Parse("b15c4a7f-0b30-4fdf-b664-991785501402")
                },
            });
		}
	}
}
