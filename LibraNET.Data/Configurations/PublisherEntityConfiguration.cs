using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
	{
		public void Configure(EntityTypeBuilder<Publisher> builder)
		{
			builder.HasData(new Publisher[]
			{
				new Publisher
				{
					Id = Guid.Parse("d910ff66-1bc5-4024-8824-42905435f749"),
					Name = "Penguin Random House",
					WebsiteURL = "https://www.penguinrandomhouse.com/"
				},
				new Publisher
				{
					Id = Guid.Parse("ec896ef0-6aee-44c6-817c-ca28c7a22ac3"),
					Name = "Hachette Livre",
					WebsiteURL = "https://www.hachette.com/en/"
				},
				new Publisher
				{
					Id = Guid.Parse("1fe0e05b-8bf7-4034-a531-cbf1ceedfeae"),
					Name = "Harper Collins",
					WebsiteURL = "https://www.harpercollins.com/"
				},
				new Publisher
				{
					Id = Guid.Parse("326d34d0-1613-4d97-a408-cc448fdd98de"),
					Name = "Macmillan Publishers",
					WebsiteURL = "https://us.macmillan.com/"
				},
				new Publisher
				{
					Id = Guid.Parse("965bc0c9-e32c-4497-9765-ada17c48bdb7"),
					Name = "Bloomsbury",
					WebsiteURL = "https://www.bloomsbury.com/uk/"
				},
				new Publisher
				{
					Id = Guid.Parse("57822c42-f2e5-4b20-91ea-c5708d69268c"),
					Name = "Insight Editions",
					WebsiteURL = "https://insighteditions.com/"
				},
				new Publisher
				{
					Id = Guid.Parse("b87a72b0-cd7a-43f6-aebf-56e2e9a3ea9a"),
					Name = "McGraw-Hill Education",
					WebsiteURL = "https://www.mheducation.com/"
				}
			});
		}
	}
}
