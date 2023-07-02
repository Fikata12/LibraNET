using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(new Category[]
			{
				new Category
				{
					Id = Guid.Parse("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a"),
					Name = "Art"
				},
				new Category
				{
					Id = Guid.Parse("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed"),
					Name = "Fiction"
				},
				new Category
				{
					Id = Guid.Parse("6592963c-fa66-4732-9d43-e7f9efd54556"),
					Name = "Science"
				},
				new Category
				{
					Id = Guid.Parse("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e"),
					Name = "Business & Finance"
				},
				new Category
				{
					Id = Guid.Parse("161ec94a-5eca-4fdf-8dd6-485675b4b624"),
					Name = "Children"
				},
				new Category
				{
					Id = Guid.Parse("1dd3c6f1-da15-421e-90a7-d8cbb8449371"),
					Name = "History"
				},
				new Category
				{
					Id = Guid.Parse("c577d932-8104-4903-95f3-23d6ab5a25f0"),
					Name = "Romance"
				},
				new Category
				{
					Id = Guid.Parse("b15c4a7f-0b30-4fdf-b664-991785501402"),
					Name = "Biography"
				}
			});
		}
	}
}
