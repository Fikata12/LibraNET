using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.HasData(new Author[]
			{
				new Author
				{
					Id = Guid.Parse("7345ddb8-f6da-4f88-aedc-783cee9540ec"),
					Name = "Jim C. Hines",
					Description = "Jim C. Hines is the author of numerous science fiction and fantasy novels, including the Janitors of the Postapocalypse trilogy, the Magic ex Libris series, the Princess series of fairy tale retellings, and the humorous Goblin Quest trilogy. He’s an active blogger, and won the 2012 Hugo Award for Best Fan Writer. He lives in mid-Michigan with his family.",
					ImagePath = "~/Images/Authors/9922bd91-535d-47f1-b277-e905e1ba6c14.jpg"
				},
			});
		}
	}
}
