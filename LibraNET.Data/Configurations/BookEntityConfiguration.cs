﻿using LibraNET.Data.Models;
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
				ImageId = Guid.Parse("e97e05ae-a5ab-4096-b9b8-0c2a3d05d8a9"),
				Price = 27,
				AvailableCount = 20,
				PublisherName = "Random House Worlds",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("ee5aea48-22b6-44bc-bfee-309290f19c35"),
				Title = "Fable: Blood of Heroes",
				ISBN = "9780345542342",
				PublicationDate = DateTime.Parse("04.08.2015"),
				Description = "Deep in Albion’s darkest age, long before once upon a time . . . Heroes are thought to be gone from the land. So why have the bards begun singing of them once more? For Fable newcomers and dedicated fans alike, Blood of Heroes delves into a never-before-glimpsed era, telling the tale of a band of adventurers who come together to defend a kingdom in desperate need. The city of Brightlodge is awash with Heroes from every corner of Albion, all eager for their next quest. When someone tries to burn down the Cock and Bard inn, four Heroes find themselves hastily thrown together, chasing outlaws through sewers, storming a riverboat full of smugglers, and placing their trust in a most unlikely ally. As the beginnings of a deadly plot are revealed, it becomes clear that Heroes have truly arrived—and so have villains. What connects the recent events in Brightlodge to rumors about a malicious ghost and a spate of unsolved deaths in the nearby mining town of Grayrock? Unless Albion’s bravest Heroes can find the answer, the dawn of a new age could be extinguished before it even begins.",
				PageCount = 336,
				Language = "English",
				ImageId = Guid.Parse("0659ada7-ef7a-4dc6-8977-53bd67540e90"),
				Price = 16,
				AvailableCount = 10,
				PublisherName = "Random House Worlds",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("5f619a68-3e7f-448e-b352-717915da20e5"),
				Title = "The Wager",
				ISBN = "9780385534260",
				PublicationDate = DateTime.Parse("18.04.2023"),
				Description = "On January 28, 1742, a ramshackle vessel of patched-together wood and cloth washed up on the coast of Brazil. Inside were thirty emaciated men, barely alive, and they had an extraordinary tale to tell. They were survivors of His Majesty’s Ship the Wager, a British vessel that had left England in 1740 on a secret mission during an imperial war with Spain. While the Wager had been chasing a Spanish treasure-filled galleon known as “the prize of all the oceans,” it had wrecked on a desolate island off the coast of Patagonia. The men, after being marooned for months and facing starvation, built the flimsy craft and sailed for more than a hundred days, traversing nearly 3,000 miles of storm-wracked seas. They were greeted as heroes. But then … six months later, another, even more decrepit craft landed on the coast of Chile. This boat contained just three castaways, and they told a very different story. The thirty sailors who landed in Brazil were not heroes – they were mutineers. The first group responded with countercharges of their own, of a tyrannical and murderous senior officer and his henchmen. It became clear that while stranded on the island the crew had fallen into anarchy, with warring factions fighting for dominion over the barren wilderness. As accusations of treachery and murder flew, the Admiralty convened a court martial to determine who was telling the truth. The stakes were life-and-death—for whomever the court found guilty could hang. The Wager is a grand tale of human behavior at the extremes told by one of our greatest nonfiction writers. Grann’s recreation of the hidden world on a British warship rivals the work of Patrick O’Brian, his portrayal of the castaways’ desperate straits stands up to the classics of survival writing such as The Endurance, and his account of the court martial has the savvy of a Scott Turow thriller. As always with Grann’s work, the incredible twists of the narrative hold the reader spellbound.",
				PageCount = 352,
				Language = "English",
				ImageId = Guid.Parse("cb63f8e6-b7e7-4ac3-adad-fdf896c65d03"),
				Price = 30,
				AvailableCount = 23,
				PublisherName = "Doubleday",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("cd6c5819-53e3-4024-9216-ae0f6502996d"),
				Title = "Never Never",
				ISBN = "9781335004888",
				PublicationDate = DateTime.Parse("28.02.2023"),
				Description = "Charlie Wynwood and Silas Nash have been best friends since they could walk. They've been in love since the age of fourteen. But as of this morning...they are complete strangers. Their first kiss, their first fight, the moment they fell in love...every memory has vanished. Now Charlie and Silas must work together to uncover the truth about what happened to them and why.\r\n\r\nBut the more they learn about the couple they used to be...the more they question why they were ever together to begin with. Forgetting is terrifying, but remembering may be worse.",
				PageCount = 416,
				Language = "English",
				ImageId = Guid.Parse("d0829ed0-e541-4cd3-94d4-703173069313"),
				Price = 17.99m,
				AvailableCount = 7,
				PublisherName = "Canary Street Press",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
				Title = "The Game Master: Mansion Mystery",
				ISBN = "9780063025134",
				PublicationDate = DateTime.Parse("01.03.2022"),
				Description = "Rebecca Zamolo has managed to foil the Game Master’s plans before, but this time the Game Master has snake-napped Nacho, her good friend Miguel’s pet. No way is Becca going to let the Game Master get away with this dastardly plan. But when the clues lead Becca and her new friends in the direction of the one house in their entire neighborhood that none of them ever want to go near, they know they have no choice but to screw up their courage and dare to investigate, if they want to rescue Nacho. But the problem is that getting into the superspooky house is way easier than getting out. The Game Master is up to their old tricks, and Becca, Matt, Kylie, Frankie, and Miguel are going to have to face their fears and use all their smarts and strengths to solve the puzzles and games and save the day. Mansion Mystery is another action-packed adventure from New York Times bestselling authors and super-sleuthing team Rebecca and Matt Zamolo, stars of the hugely popular Game Master Network.",
				PageCount = 176,
				Language = "English",
				ImageId = Guid.Parse("caf91194-c199-436c-9a27-adc16135fc3b"),
				Price = 17.99m,
				AvailableCount = 8,
				PublisherName = "HarperCollins",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("be157e3e-161f-4764-a782-2bec929bcd94"),
				Title = "Meathead",
				ISBN = "9780544018464",
				PublicationDate = DateTime.Parse("10.05.2016"),
				Description = "For succulent results every time, nothing is more crucial than understanding the science behind the interaction of food, fire, heat, and smoke. This is the definitive guide to the concepts, methods, equipment, and accessories of barbecue and grilling. The founder and editor of the world's most popular BBQ and grilling website, AmazingRibs.com, and a BBQ Hall of Fame member, “Meathead” Goldwyn applies the latest research to backyard cooking and 118 thoroughly tested recipes. He explains why dry brining is better than wet brining; how marinades really work; why rubs shouldn't have salt in them; how heat and temperature differ; the importance of digital thermometers; why searing doesn't seal in juices; how salt penetrates but spices don't; when charcoal beats gas and when gas beats charcoal; how to calibrate and tune a grill or smoker; how to keep fish from sticking; cooking with logs; the strengths and weaknesses of the new pellet cookers; tricks for rotisserie cooking; why cooking whole animals is a bad idea, which grill grates are best;and why beer-can chicken is a waste of good beer and nowhere close to the best way to cook a bird. Lavishly designed with hundreds of illustrations and full-color photos by the author, this book contains all the sure-fire recipes for traditional American favorites and many more outside-the-box creations. You'll get recipes for all the great regional barbecue sauces; rubs for meats and vegetables; Last Meal Ribs, Simon & Garfunkel Chicken; Schmancy Smoked Salmon; The Ultimate Turkey; Texas Brisket; Perfect Pulled Pork; Sweet & Sour Pork with Mumbo Sauce; Whole Hog; Steakhouse Steaks; Diner Burgers; Prime Rib; Brazilian Short Ribs; Rack Of Lamb Lollipops; Huli-Huli Chicken; Smoked Trout Florida Mullet –Style; Baja Fish Tacos; Lobster, and many more.",
				PageCount = 400,
				Language = "English",
				ImageId = Guid.Parse("ca561a7e-3509-4fdf-a22c-869b219d6db0"),
				Price = 35,
				AvailableCount = 4,
				PublisherName = "Harvest",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("5d437d09-15fd-4969-856d-6694f1d75f5f"),
				Title = "Sixty-One",
				ISBN = "9781250276711",
				PublicationDate = DateTime.Parse("20.06.2023"),
				Description = "The day after future NBA superstar Chris Paul signed his letter of intent to play college basketball for Wake Forest, he received a world-shattering phone call. His grandfather, Nathaniel \"Papa\" Jones, a pillar of the Winston-Salem community where he owned and operated the first Black-owned service station in North Carolina, was mugged and ultimately died from a heart attack resulting from the assault. His funeral filled the largest church in the county, which held over one thousand people. He was sixty-one years old. The day after burying his grandfather, Chris was coping the best way he knew how: by playing basketball for his high school team. After pouring in shot after shot, his last attempt was an airball purposely flung out of bounds from the foul line before Chris exited the game. The next day, local news headlines declared that he fell six points shy of the statewide single game high school scoring record. But he accomplished exactly what he set out to do: scoring sixty-one points, one for each year of life lived by his grandfather. In Sixty-One, Chris opens up about life beyond basketball and the role his grandfather played in molding him into the man and father he is today. He’ll speak about the foundation of faith and family he built his life upon, what it means to be a positive light within your community and beyond, and the importance of setting the proper example for future generations. Most importantly, Chris will talk about his home, Winston-Salem, and the close-knit family and village that raised him to become one of the most respected leaders in all of sports.",
				PageCount = 336,
				Language = "English",
				ImageId = Guid.Parse("80e12726-1c6d-40b6-9db7-3a1a4d77a172"),
				Price = 30,
				AvailableCount = 9,
				PublisherName = "St. Martin's Press",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
				Title = "Harry Potter and the Order of the Phoenix (Illustrated Edition)",
				ISBN = "9781408845684",
				PublicationDate = DateTime.Parse("11.10.2022"),
				Description = "As the Order of the Phoenix keeps watch over Harry Potter, troubled times have come to Hogwarts in a year filled with secrets, subterfuge and suspicion. The deliciously dark fifth instalment of Jim Kay's inspired reimagining of J.K. Rowling's classic series is an epic artistic achievement, featuring over 160 illustrations in an astonishing range of visual styles. Now an exciting new collaboration brings together two virtuoso artistic talents, as Kate Greenaway Medal winner Jim Kay is joined by acclaimed guest illustrator Neil Packer, winner of the 2021 BolognaRagazzi Award for non-fiction. Prepare to be enchanted once again as Jim Kay depicts J.K. Rowling's wizarding world with the dazzling artistic alchemy fans around the globe have come to know and love, perfectly complemented by Neil Packer's own unique and eclectic illustrations, skilfully woven into the heart of the story. This is a stunning visual feast of a book, filled with dark magical delights for both fans and new readers alike. Breathtaking scenes, iconic locations and unforgettable characters await inside – Luna Lovegood, Professor Umbridge, Grawp the giant, and many more – as Harry Potter and Dumbledore's Army prepare for the coming battle against Lord Voldemort. Perfect for Potterheads of all ages!",
				PageCount = 576,
				Language = "English",
				ImageId = Guid.Parse("e721e612-2a18-4ede-b7cb-adbe45a62d91"),
				Price = 26.99m,
				AvailableCount = 3,
				PublisherName = "Bloomsbury",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
				Title = "Harry Potter and the Philosopher’s Stone (Illustrated Edition)",
				ISBN = "9781526602381",
				PublicationDate = DateTime.Parse("23.08.2018"),
				Description = "Jim Kay's dazzling depiction of J.K. Rowling's wizarding world has won legions of fans since the Illustrated Edition of Harry Potter and the Philosopher's Stone was published in hardback in 2015, becoming a bestseller around the world. This irresistible smaller-format paperback edition of J.K. Rowling's novel brings the magic of Jim Kay's illustration to new readers, with full-colour pictures, French flaps and a handsome poster pull-out at the back of the book. This edition has been beautifully redesigned with selected illustration highlights – the fully illustrated edition is still available in hardback. When a letter arrives for Harry Potter on his eleventh birthday, a decade-old secret is revealed to him that apparently he's the last to know. An incredible adventure is about to begin!",
				PageCount = 256,
				Language = "English",
				ImageId = Guid.Parse("db1a73c5-360a-43de-8824-3119f8594981"),
				Price = 10.99m,
				AvailableCount = 14,
				PublisherName = "Bloomsbury",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("c482f838-87c4-4443-b143-62637d4f97e7"),
				Title = "Where Is My Office?",
				ISBN = "9781399405171",
				PublicationDate = DateTime.Parse("25.05.2023"),
				Description = "In the era of WFH, hybrid working and flexible hours, going to the office is no longer what it used to be. Many businesses and organizations, as well as the entire commercial real estate sector, are struggling to address their new workplace dilemmas in the aftermath of the COVID-19 pandemic. With the rise of diverse working practices and new technological innovations, the traditional office space no longer serves the needs of the workforce. And with increasing numbers of staff now comfortable with a degree of working from home, how can companies assess their longer-term workspace needs? This new follow-up edition of Where Is My Office?, fully revised and updated to reflect the true impact of the pandemic on the workplace, highlights some of the bold new frameworks and practical considerations for business leaders, workplace practitioners and those involved in commercial real estate as they navigate the complex post-pandemic working landscape. Authors Chris Kane and Eugenia Anastassiou draw upon their extensive knowledge and experience to investigate the new-found significance of innovative corporate real estate thinking in modern workplaces. Where is My Office?: The Post-Pandemic Edition is a must-read for any business leader or senior manager looking to revitalize their workplace in a post-pandemic environment, and to develop a greater understanding of the beneficial impacts that creative workplace strategies that harness the relationship between people, place, technology, and the environment can have upon their organization's success.",
				PageCount = 288,
				Language = "English",
				ImageId = Guid.Parse("cf822511-25b1-4ee3-b6e2-ab7721162cfc"),
				Price = 16,
				AvailableCount = 17,
				PublisherName = "Bloomsbury",
				AddedDate = DateTime.Now
				},
                new Book
                {
                Id = Guid.Parse("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                Title = "The Rise of Theodore Roosevelt",
                ISBN = "9781400069651",
                PublicationDate = DateTime.Parse("23.11.2010"),
                Description = "This classic biography is the story of seven men—a naturalist, a writer, a lover, a hunter, a ranchman, a soldier, and a politician—who merged at age forty-two to become the youngest President in history. The Rise of Theodore Roosevelt begins at the apex of his international prestige. That was on New Year’s Day, 1907, when TR, who had just won the Nobel Peace Prize, threw open the doors of the White House to the American people and shook 8,150 hands. One visitor remarked afterward, “You go to the White House, you shake hands with Roosevelt and hear him talk—and then you go home to wring the personality out of your clothes.” The rest of this book tells the story of TR’s irresistible rise to power. During the years 1858–1901, Theodore Roosevelt transformed himself from a frail, asthmatic boy into a full-blooded man. Fresh out of Harvard, he simultaneously published a distinguished work of naval history and became the fist-swinging leader of a Republican insurgency in the New York State Assembly. He chased thieves across the Badlands of North Dakota with a copy of Anna Karenina in one hand and a Winchester rifle in the other. Married to his childhood sweetheart in 1886, he became the country squire of Sagamore Hill on Long Island, a flamboyant civil service reformer in Washington, D.C., and a night-stalking police commissioner in New York City. As assistant secretary of the navy, he almost single-handedly brought about the Spanish-American War. After leading “Roosevelt’s Rough Riders” in the famous charge up San Juan Hill, Cuba, he returned home a military hero, and was rewarded with the governorship of New York. In what he called his “spare hours” he fathered six children and wrote fourteen books. By 1901, the man Senator Mark Hanna called “that damned cowboy” was vice president. Seven months later, an assassin’s bullet gave TR the national leadership he had always craved. His is a story so prodigal in its variety, so surprising in its turns of fate, that previous biographers have treated it as a series of haphazard episodes.",
                PageCount = 960,
                Language = "English",
				ImageId = Guid.Parse("c9a2a08a-8b4c-4603-9abb-af67ec9d92a1"),
                Price = 40,
                AvailableCount = 4,
                PublisherName = "Random House",
                AddedDate = DateTime.Now
                },
                new Book
                {
                Id = Guid.Parse("485c54bc-b294-420b-ba53-c4c219af644d"),
                Title = "N'ice Cream",
                ISBN = "9780735210455",
                PublicationDate = DateTime.Parse("17.05.2016"),
                Description = "Just in time to beat the summer heat, N’ice Cream offers 80 decadent and healthy ice cream recipes made from all-natural, wholesome vegan ingredients like fruits, berries, and plant-based milks and nuts–as the authors say, “no weird stuff.” Get ready to have your ice cream and eat it too. Award-winning Finnish author Virpi and coauthor Tuulia show that making your own ice cream can be easy and good for you at the same time. These recipes can be made with or without an ice cream maker, and include foolproof instant ice creams that can be savored right away. As Tuulia and Virpi say, people deserve to eat goodies without feeling crappy afterwards, and now they can; all the recipes are dairy-free, gluten-free, and refined-sugar-free, and many are nut-free and raw as well. These delicious recipes include creamy ice creams, soft serves, and milkshakes; fresh sorbets and popsicles; party fare like ice cream cakes, sauces, and more. Enjoy light, summery treats like Coconut Water Coolers and Apple Avocado Mint Popsicles, or relish more decadent fare like the Dreamy Chocolate Sundae and Mint Chocolate Ice Cream Sandwiches. The book itself is gorgeously designed with mouth-watering photographs. Perfect for those who want to devour summer treats without guilt, N’ice Cream is about to make your summer a whole lot more delicious.",
                PageCount = 224,
                Language = "English",
				ImageId = Guid.Parse("46872adf-b4ba-4857-b5fa-028f95f3a233"),
                Price = 25,
                AvailableCount = 6,
                PublisherName = "Avery",
                AddedDate = DateTime.Now
                },
                new Book
                {
                Id = Guid.Parse("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                Title = "Spare",
                ISBN = "9780593593806",
                PublicationDate = DateTime.Parse("10.01.2023"),
                Description = "It was one of the most searing images of the twentieth century: two young boys, two princes, walking behind their mother’s coffin as the world watched in sorrow—and horror. As Princess Diana was laid to rest, billions wondered what Prince William and Prince Harry must be thinking and feeling—and how their lives would play out from that point on. For Harry, this is that story at last. Before losing his mother, twelve-year-old Prince Harry was known as the carefree one, the happy-go-lucky Spare to the more serious Heir. Grief changed everything. He struggled at school, struggled with anger, with loneliness—and, because he blamed the press for his mother’s death, he struggled to accept life in the spotlight. At twenty-one, he joined the British Army. The discipline gave him structure, and two combat tours made him a hero at home. But he soon felt more lost than ever, suffering from post-traumatic stress and prone to crippling panic attacks. Above all, he couldn’t find true love. Then he met Meghan. The world was swept away by the couple’s cinematic romance and rejoiced in their fairy-tale wedding. But from the beginning, Harry and Meghan were preyed upon by the press, subjected to waves of abuse, racism, and lies. Watching his wife suffer, their safety and mental health at risk, Harry saw no other way to prevent the tragedy of history repeating itself but to flee his mother country. Over the centuries, leaving the Royal Family was an act few had dared. The last to try, in fact, had been his mother. . . .  For the first time, Prince Harry tells his own story, chronicling his journey with raw, unflinching honesty. A landmark publication, Spare is full of insight, revelation, self-examination, and hard-won wisdom about the eternal power of love over grief.",
                PageCount = 416,
                Language = "English",
				ImageId = Guid.Parse("296983b7-6271-4133-ac16-460f54fc3e10"),
                Price = 36,
                AvailableCount = 15,
                PublisherName = "Random House",
                AddedDate = DateTime.Now
                }
            });
		}
	}
}