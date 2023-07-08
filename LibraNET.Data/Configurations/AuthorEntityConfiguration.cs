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
				new Author
				{
					Id = Guid.Parse("784e00df-f751-48d9-a25d-129253723ff3"),
					Name = "David Grann",
					Description = "DAVID GRANN is the author of the #1 New York Times bestsellers KILLERS OF THE FLOWER MOON and THE LOST CITY OF Z. KILLERS OF THE FLOWER MOON was a finalist for The National Book Award and won an Edgar Allan Poe Award. He is also the author of THE WHITE DARKNESS and the collection THE DEVIL AND SHERLOCK HOLMES. Grann’s storytelling has garnered several honors, including a George Polk Award. He lives with his wife and children in New York.",
					ImagePath = "~/Images/Authors/c2afa02d-edba-439e-8179-c834cdbf63ff.jpg"
				},
				new Author
				{
					Id = Guid.Parse("c96a6380-0d69-4ee6-ab0e-5ea5827370d3"),
					Name = "Colleen Hoover",
					Description = "Colleen Hoover is the #1 New York Times bestselling author of more than twenty-three novels, including It Starts with Us, It Ends with Us, All Your Perfects, Ugly Love, and Verity. In 2015, Colleen and her family founded a nonprofit called The Bookworm Box, a bookstore and monthly book subscription service. Colleen lives in Texas with her husband and their three boys.",
					ImagePath = "~/Images/Authors/87af0318-95ab-43fb-a087-4488e97f98c7.jpg"
				},
				new Author
				{
					Id = Guid.Parse("0a26d53b-5051-4b2c-a372-10d8cf190747"),
					Name = "Tarryn Fisher",
					Description = "Tarryn Fisher is the New York Times and USA TODAY bestselling author of nine novels. Born a sun hater, she currently makes her home in Seattle, Washington, with her children, husband, and psychotic husky. She loves connecting with her readers on Instagram.",
					ImagePath = "~/Images/Authors/3dbf456f-a7ca-4a4f-aa56-149582aae280.jpg"
				},
				new Author
				{
					Id = Guid.Parse("77a7d531-c916-4cec-bac8-0498f0fb060b"),
					Name = "Rebecca Zamolo",
					Description = "Matt Slays and Rebecca Zamolo, the stars and creators of the mega-popular Game Master Network, are two of the most popular YouTubers in the world. With more than 30 million subscribers across their social media platforms, Matt and Rebecca have become popular stars with a highly engaged audience.",
					ImagePath = "~/Images/Authors/02b07984-b4ba-4fff-8b66-231e8b6a59f1.jpg"
				},
				new Author
				{
					Id = Guid.Parse("003dceff-365f-4c2f-ba0e-89f1fa58d380"),
					Name = "Matt Slays",
					Description = "Matt Slays and Rebecca Zamolo, the stars and creators of the mega-popular Game Master Network, are two of the most popular YouTubers in the world. With more than 30 million subscribers across their social media platforms, Matt and Rebecca have become popular stars with a highly engaged audience.",
					ImagePath = "~/Images/Authors/b10bf8fa-87b9-4a05-abd1-10f3ce882d08.jpg"
				},
				new Author
				{
					Id = Guid.Parse("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab"),
					Name = "Meathead Goldwyn",
					Description = "The president and founder of AmazingRibs.com, one of the most popular online barbecuing sites, MEATHEAD and has penned hundreds of articles about food and drink for the Washington Post, the Chicago Tribune, AOL, Wine Spectator, and a weekly column for Huffington Post. His photos have appeared in such publications as Time and Playboy.  He judges barbecue cookoffs from Kansas City to Memphis, including the Jack Daniels World Championship Invitational Barbecue and the College Football Hall of Fame Barbecue.",
					ImagePath = "~/Images/Authors/70cf8640-398d-49a1-bce1-1cb6d8557cce.jpg"
				},
				new Author
				{
					Id = Guid.Parse("433d825d-d80b-4a3f-8894-c14514f04c1c"),
					Name = "Rux Martin",
					Description = "Rux Martin is an independent editor specializing in cookbooks, books about food, food memoirs, diet books, and nonfiction. She was editorial director of her own imprint at Houghton Mifflin Harcourt, where she published some of the most distinctive and authoritative voices in food. Authors she has worked with include Jacques Pépin, Dorie Greenspan, Michael Solomonov and Steven Cook, Antoni Porowski, Pati Jinich, Maangchi Kim, Ivan Orkin, Molly Katzen, Marcus Samuelsson, Bruce Aidells, Ruth Reichl (The Gourmet Cookbook), and Judith Jones. Many of the books she shaped reached the New York Times bestseller list, including Antoni in the Kitchen, The Essential Scratch & Sniff Guide to Becoming a Wine Expert, Hello, Cupcake!, Around My French Table, and Zahav. She helped launch Chapters, a small publishing house in Vermont that made a national name for itself with many award-winning cookbooks. She was also one of the launch editors of Eating Well magazine, where she oversaw the food and food photography. She began her career as a freelance writer for Vermont newspapers and national magazines.",
					ImagePath = "~/Images/Authors/52372469-66a6-4ef9-8988-97a5d97724cf.jpg"
				},
				new Author
				{
					Id = Guid.Parse("5014b5d5-0d84-4019-a975-05b3a7b67f9c"),
					Name = "Chris Paul",
					Description = "Chris Paul is a twelve-time NBA All-Star, two-time Olympic Gold medalist, and the former president of the National Basketball Players Association. Off the court, he’s a father, husband, entrepreneur, activist, and philanthropist. He founded the CP3 Basketball Academy. The Chris Paul Family Foundation continues to provide resources that enrich underserved communities.",
					ImagePath = "~/Images/Authors/5fc12440-02b2-486d-9e92-abc57885fd6b.jpg"
				},
				new Author
				{
					Id = Guid.Parse("e1054010-cccb-4f94-8e10-1611ffd6c692"),
					Name = "J.K. Rowling",
					Description = "J.K. Rowling is the author of the enduringly popular Harry Potter series, as well as several stand-alone novels and a bestselling crime fiction series. After the idea for Harry Potter came to her on a delayed train journey in 1990, she plotted out and started writing the series of seven books and the first, Harry Potter and the Philosopher’s Stone, was published in the UK in 1997. The series took another ten years to complete, concluding in 2007 with the publication of Harry Potter and the Deathly Hallows. Smash hit movie adaptations followed. The Harry Potter books have now sold over 600 million copies worldwide in 85 languages and been listened to as audiobooks for over one billion hours. To accompany the series, J.K. Rowling wrote three short companion volumes for charity: Quidditch Through the Ages and Fantastic Beasts and Where to Find Them, in aid of Comic Relief and Lumos, and The Tales of Beedle the Bard, in aid of Lumos. Fantastic Beasts and Where to Find Them went on to inspire a new series of films featuring Magizoologist Newt Scamander. Harry’s story as a grown-up was continued in a stage play, Harry Potter and the Cursed Child, which J.K. Rowling wrote with playwright Jack Thorne and director John Tiffany, and which is now playing in multiple locations around the world. In 2020, she returned to publishing for younger children with the fairy tale The Ickabog, the royalties from which she donated to her charitable trust, Volant, to help charities working to alleviate the social effects of the COVID-19 pandemic. Her latest children’s novel, The Christmas Pig, was published in 2021. J.K. Rowling has received many awards and honours for her writing, including the OBE and Companion of Honour, the Hans Christian Andersen Award and a Blue Peter Gold Badge. She supports a wide number of humanitarian causes through Volant, and is the founder of the international children’s care reform charity Lumos. J.K. Rowling lives in Scotland with her family.",
					ImagePath = "~/Images/Authors/f9bccf28-07ba-472e-aeb8-e5859d30060c.jpg"
				},
				new Author
				{
					Id = Guid.Parse("3bca8dab-0014-4e00-9024-bdfe1be5bb24"),
					Name = "Chris Kane",
					Description = "Chris Kane has worked in the Corporate Real Estate sector for over 30 years, having operated as the Vice President of International Corporate Real Estate for The Walt Disney Company, before acting as Head of Corporate Real Estate at the BBC, where he was responsible for the creation of MediaCityUK in Salford and oversaw the £1bn development of Broadcasting House, as well as the inception of White City innovation/creative quarter in West London. Chris is also a founding member and director of EverythingOmni, a global advisory, advocacy and thought leadership group, focused on workplace development and innovation.",
					ImagePath = "~/Images/Authors/3a5625b9-a4eb-475e-bbc1-e759dcf8ea7d.jpg"
				},
                new Author
                {
                    Id = Guid.Parse("b2f940f9-91d8-454a-83f8-47e43572fed3"),
                    Name = "Edmund Morris",
                    Description = "Edmund Morris was born and educated in Kenya and attended college in South Africa. He worked as an advertising copywriter in London before immigrating to the United States in 1968. His first book, The Rise of Theodore Roosevelt, won the Pulitzer Prize and the National Book Award in 1980. Its sequel, Theodore Rex, won the Los Angeles Times Book Prize for Biography in 2001. In between these two books, Morris became President Reagan’s authorized biographer and wrote the national bestseller Dutch: A Memoir of Ronald Reagan. He then completed his trilogy on the life of the twenty-sixth president with Colonel Roosevelt, also a bestseller, and has published Beethoven: The Universal Composer and This Living Hand and Other Essays. Edison is his final work of biography. He was married to fellow biographer Sylvia Jukes Morris for fifty-two years. Edmund Morris died in 2019.",
                    ImagePath = "~/Images/Authors/c8150876-a823-4f18-a8d0-626513d25c4d.jpg"
                },
                new Author
                {
                    Id = Guid.Parse("9e230070-3689-4b47-83d8-92befb937998"),
                    Name = "Virpi Mikkonen",
                    Description = "Virpi Mikkonen is leading healthy recipe designer, health coach, author of 5 cookbooks and an entrepreneur specialized in beautiful nourishing food & natural lifestyle. Known for her highly visual and joyful approach to wholesome food and feeling good, she has gained a wide success among the foodies & wellness seekers around the world.",
                    ImagePath = "~/Images/Authors/0cc23000-3de8-4321-a1fc-c5cc620aa9f1.jpg"
                },
                new Author
                {
                    Id = Guid.Parse("04e87959-6cbb-4622-8206-fa729197d3e7"),
                    Name = "Tuulia Talvio",
                    Description = "Originally from the western part of Finland, Tuulia was raised near the sea. Presently, she resides in Helsinki with her husband and son. While she often dreams of basking in the sun during winters, she remains deeply connected to her Nordic heritage, appreciating the unique magic and abundance of delicious berries found in the northern region.",
                    ImagePath = "~/Images/Authors/fc0494d9-d3da-433f-b0f1-3760d0ce00ca.jpg"
                },
                new Author
                {
                    Id = Guid.Parse("241d25a6-e7d1-4c66-b080-7845342274f1"),
                    Name = "Prince Harry, The Duke of Sussex",
                    Description = "Prince Harry, The Duke of Sussex, is a husband, father, humanitarian, military veteran, mental wellness advocate, and environmentalist. He resides in Santa Barbara, California, with his family and three dogs.",
                    ImagePath = "~/Images/Authors/34773977-1191-4385-839e-33bc59a200e1.jpg"
                }
            });
		}
	}
}
