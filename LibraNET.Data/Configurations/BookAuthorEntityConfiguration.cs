using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace LibraNET.Data.Configurations
{
	internal class BookAuthorEntityConfiguration : IEntityTypeConfiguration<BookAuthor>
	{
		public void Configure(EntityTypeBuilder<BookAuthor> builder)
		{
			builder
				.HasKey(e => new { e.BookId, e.AuthorId });

			builder.HasData(new BookAuthor[]
			{
				new BookAuthor
				{
					BookId = Guid.Parse("234e7f45-82e2-4951-b993-0e0360daff8c"),
					AuthorId = Guid.Parse("7345ddb8-f6da-4f88-aedc-783cee9540ec")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("ee5aea48-22b6-44bc-bfee-309290f19c35"),
					AuthorId = Guid.Parse("7345ddb8-f6da-4f88-aedc-783cee9540ec")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("5f619a68-3e7f-448e-b352-717915da20e5"),
					AuthorId = Guid.Parse("784e00df-f751-48d9-a25d-129253723ff3")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("cd6c5819-53e3-4024-9216-ae0f6502996d"),
					AuthorId = Guid.Parse("c96a6380-0d69-4ee6-ab0e-5ea5827370d3")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("cd6c5819-53e3-4024-9216-ae0f6502996d"),
					AuthorId = Guid.Parse("0a26d53b-5051-4b2c-a372-10d8cf190747")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
					AuthorId = Guid.Parse("77a7d531-c916-4cec-bac8-0498f0fb060b")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
					AuthorId = Guid.Parse("003dceff-365f-4c2f-ba0e-89f1fa58d380")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("be157e3e-161f-4764-a782-2bec929bcd94"),
					AuthorId = Guid.Parse("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("be157e3e-161f-4764-a782-2bec929bcd94"),
					AuthorId = Guid.Parse("433d825d-d80b-4a3f-8894-c14514f04c1c")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("5d437d09-15fd-4969-856d-6694f1d75f5f"),
					AuthorId = Guid.Parse("5014b5d5-0d84-4019-a975-05b3a7b67f9c")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
					AuthorId = Guid.Parse("e1054010-cccb-4f94-8e10-1611ffd6c692")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
					AuthorId = Guid.Parse("e1054010-cccb-4f94-8e10-1611ffd6c692")
				},
				new BookAuthor
				{
					BookId = Guid.Parse("c482f838-87c4-4443-b143-62637d4f97e7"),
					AuthorId = Guid.Parse("3bca8dab-0014-4e00-9024-bdfe1be5bb24")
				},
                new BookAuthor
                {
                    BookId = Guid.Parse("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                    AuthorId = Guid.Parse("b2f940f9-91d8-454a-83f8-47e43572fed3")
                },
                new BookAuthor
                {
                    BookId = Guid.Parse("485c54bc-b294-420b-ba53-c4c219af644d"),
                    AuthorId = Guid.Parse("9e230070-3689-4b47-83d8-92befb937998")
                },
                new BookAuthor
                {
                    BookId = Guid.Parse("485c54bc-b294-420b-ba53-c4c219af644d"),
                    AuthorId = Guid.Parse("04e87959-6cbb-4622-8206-fa729197d3e7")
                },new BookAuthor
                {
                    BookId = Guid.Parse("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                    AuthorId = Guid.Parse("241d25a6-e7d1-4c66-b080-7845342274f1")
                },new BookAuthor
                {
                    BookId = Guid.Parse("000"),
                    AuthorId = Guid.Parse("000")
                },
            });
		}
	}
}
