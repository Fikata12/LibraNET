using LibraNET.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNET.Data.Configurations
{
	internal class BookEntityConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasData(new Book[]
			{
				new Book
				{
				Id = Guid.Parse("234e7f45-82e2-4951-b993-0e0360daff8c"),
				Title = "Terminal Peace",
				ISBN = "9780756412807",
				PublicationDate = DateTime.Parse("23.08.2022"),
				Description = "Marion “Mops” Adamopoulos and her team were trained to clean spaceships. They were absolutely not trained to fight an interplanetary war with the xenocidal Prodryans or to make first contact with the Jynx, a race who might not be as primitive as they seem. But if there’s one lesson Mops and her crew have learned, it’s that things like “training” and “being remotely qualified” are overrated. The war is escalating. (This might be Mops’ fault.) The survival of humanity—those few who weren’t turned to feral, shambling monsters by an alien plague—as well as the fate of all other non-Prodryans, will depend on what Captain Mops and the crew of the EDFS Pufferfish discover on the ringed planet of Tuxatl. But the Jynx on Tuxatl are fighting a war of their own, and their world’s long-buried secrets could be more dangerous than the Prodryans. To make matters worse, Mops is starting to feel a little feral herself…",
				PageCount = 368,
				Language = "English",
				ImagePath = "~/Images/Books/e97e05ae-a5ab-4096-b9b8-0c2a3d05d8a9.jpg",
				Price = 27,
				AvailableCount = 20,
				PublisherId = Guid.Parse("d910ff66-1bc5-4024-8824-42905435f749"),
				AddedDate = DateTime.Now
				}
			});
		}
	}
}