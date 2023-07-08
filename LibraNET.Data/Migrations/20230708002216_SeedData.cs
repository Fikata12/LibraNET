using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("003dceff-365f-4c2f-ba0e-89f1fa58d380"), "Matt Slays and Rebecca Zamolo, the stars and creators of the mega-popular Game Master Network, are two of the most popular YouTubers in the world. With more than 30 million subscribers across their social media platforms, Matt and Rebecca have become popular stars with a highly engaged audience.", "~/Images/Authors/b10bf8fa-87b9-4a05-abd1-10f3ce882d08.jpg", "Matt Slays" },
                    { new Guid("04e87959-6cbb-4622-8206-fa729197d3e7"), "Originally from the western part of Finland, Tuulia was raised near the sea. Presently, she resides in Helsinki with her husband and son. While she often dreams of basking in the sun during winters, she remains deeply connected to her Nordic heritage, appreciating the unique magic and abundance of delicious berries found in the northern region.", "~/Images/Authors/fc0494d9-d3da-433f-b0f1-3760d0ce00ca.jpg", "Tuulia Talvio" },
                    { new Guid("0a26d53b-5051-4b2c-a372-10d8cf190747"), "Tarryn Fisher is the New York Times and USA TODAY bestselling author of nine novels. Born a sun hater, she currently makes her home in Seattle, Washington, with her children, husband, and psychotic husky. She loves connecting with her readers on Instagram.", "~/Images/Authors/3dbf456f-a7ca-4a4f-aa56-149582aae280.jpg", "Tarryn Fisher" },
                    { new Guid("241d25a6-e7d1-4c66-b080-7845342274f1"), "Prince Harry, The Duke of Sussex, is a husband, father, humanitarian, military veteran, mental wellness advocate, and environmentalist. He resides in Santa Barbara, California, with his family and three dogs.", "~/Images/Authors/34773977-1191-4385-839e-33bc59a200e1.jpg", "Prince Harry, The Duke of Sussex" },
                    { new Guid("3bca8dab-0014-4e00-9024-bdfe1be5bb24"), "Chris Kane has worked in the Corporate Real Estate sector for over 30 years, having operated as the Vice President of International Corporate Real Estate for The Walt Disney Company, before acting as Head of Corporate Real Estate at the BBC, where he was responsible for the creation of MediaCityUK in Salford and oversaw the £1bn development of Broadcasting House, as well as the inception of White City innovation/creative quarter in West London. Chris is also a founding member and director of EverythingOmni, a global advisory, advocacy and thought leadership group, focused on workplace development and innovation.", "~/Images/Authors/3a5625b9-a4eb-475e-bbc1-e759dcf8ea7d.jpg", "Chris Kane" },
                    { new Guid("433d825d-d80b-4a3f-8894-c14514f04c1c"), "Rux Martin is an independent editor specializing in cookbooks, books about food, food memoirs, diet books, and nonfiction. She was editorial director of her own imprint at Houghton Mifflin Harcourt, where she published some of the most distinctive and authoritative voices in food. Authors she has worked with include Jacques Pépin, Dorie Greenspan, Michael Solomonov and Steven Cook, Antoni Porowski, Pati Jinich, Maangchi Kim, Ivan Orkin, Molly Katzen, Marcus Samuelsson, Bruce Aidells, Ruth Reichl (The Gourmet Cookbook), and Judith Jones. Many of the books she shaped reached the New York Times bestseller list, including Antoni in the Kitchen, The Essential Scratch & Sniff Guide to Becoming a Wine Expert, Hello, Cupcake!, Around My French Table, and Zahav. She helped launch Chapters, a small publishing house in Vermont that made a national name for itself with many award-winning cookbooks. She was also one of the launch editors of Eating Well magazine, where she oversaw the food and food photography. She began her career as a freelance writer for Vermont newspapers and national magazines.", "~/Images/Authors/52372469-66a6-4ef9-8988-97a5d97724cf.jpg", "Rux Martin" },
                    { new Guid("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab"), "The president and founder of AmazingRibs.com, one of the most popular online barbecuing sites, MEATHEAD and has penned hundreds of articles about food and drink for the Washington Post, the Chicago Tribune, AOL, Wine Spectator, and a weekly column for Huffington Post. His photos have appeared in such publications as Time and Playboy.  He judges barbecue cookoffs from Kansas City to Memphis, including the Jack Daniels World Championship Invitational Barbecue and the College Football Hall of Fame Barbecue.", "~/Images/Authors/70cf8640-398d-49a1-bce1-1cb6d8557cce.jpg", "Meathead Goldwyn" },
                    { new Guid("5014b5d5-0d84-4019-a975-05b3a7b67f9c"), "Chris Paul is a twelve-time NBA All-Star, two-time Olympic Gold medalist, and the former president of the National Basketball Players Association. Off the court, he’s a father, husband, entrepreneur, activist, and philanthropist. He founded the CP3 Basketball Academy. The Chris Paul Family Foundation continues to provide resources that enrich underserved communities.", "~/Images/Authors/5fc12440-02b2-486d-9e92-abc57885fd6b.jpg", "Chris Paul" },
                    { new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"), "Jim C. Hines is the author of numerous science fiction and fantasy novels, including the Janitors of the Postapocalypse trilogy, the Magic ex Libris series, the Princess series of fairy tale retellings, and the humorous Goblin Quest trilogy. He’s an active blogger, and won the 2012 Hugo Award for Best Fan Writer. He lives in mid-Michigan with his family.", "~/Images/Authors/9922bd91-535d-47f1-b277-e905e1ba6c14.jpg", "Jim C. Hines" },
                    { new Guid("77a7d531-c916-4cec-bac8-0498f0fb060b"), "Matt Slays and Rebecca Zamolo, the stars and creators of the mega-popular Game Master Network, are two of the most popular YouTubers in the world. With more than 30 million subscribers across their social media platforms, Matt and Rebecca have become popular stars with a highly engaged audience.", "~/Images/Authors/02b07984-b4ba-4fff-8b66-231e8b6a59f1.jpg", "Rebecca Zamolo" },
                    { new Guid("784e00df-f751-48d9-a25d-129253723ff3"), "DAVID GRANN is the author of the #1 New York Times bestsellers KILLERS OF THE FLOWER MOON and THE LOST CITY OF Z. KILLERS OF THE FLOWER MOON was a finalist for The National Book Award and won an Edgar Allan Poe Award. He is also the author of THE WHITE DARKNESS and the collection THE DEVIL AND SHERLOCK HOLMES. Grann’s storytelling has garnered several honors, including a George Polk Award. He lives with his wife and children in New York.", "~/Images/Authors/c2afa02d-edba-439e-8179-c834cdbf63ff.jpg", "David Grann" },
                    { new Guid("9e230070-3689-4b47-83d8-92befb937998"), "Virpi Mikkonen is leading healthy recipe designer, health coach, author of 5 cookbooks and an entrepreneur specialized in beautiful nourishing food & natural lifestyle. Known for her highly visual and joyful approach to wholesome food and feeling good, she has gained a wide success among the foodies & wellness seekers around the world.", "~/Images/Authors/0cc23000-3de8-4321-a1fc-c5cc620aa9f1.jpg", "Virpi Mikkonen" },
                    { new Guid("b2f940f9-91d8-454a-83f8-47e43572fed3"), "Edmund Morris was born and educated in Kenya and attended college in South Africa. He worked as an advertising copywriter in London before immigrating to the United States in 1968. His first book, The Rise of Theodore Roosevelt, won the Pulitzer Prize and the National Book Award in 1980. Its sequel, Theodore Rex, won the Los Angeles Times Book Prize for Biography in 2001. In between these two books, Morris became President Reagan’s authorized biographer and wrote the national bestseller Dutch: A Memoir of Ronald Reagan. He then completed his trilogy on the life of the twenty-sixth president with Colonel Roosevelt, also a bestseller, and has published Beethoven: The Universal Composer and This Living Hand and Other Essays. Edison is his final work of biography. He was married to fellow biographer Sylvia Jukes Morris for fifty-two years. Edmund Morris died in 2019.", "~/Images/Authors/c8150876-a823-4f18-a8d0-626513d25c4d.jpg", "Edmund Morris" },
                    { new Guid("c96a6380-0d69-4ee6-ab0e-5ea5827370d3"), "Colleen Hoover is the #1 New York Times bestselling author of more than twenty-three novels, including It Starts with Us, It Ends with Us, All Your Perfects, Ugly Love, and Verity. In 2015, Colleen and her family founded a nonprofit called The Bookworm Box, a bookstore and monthly book subscription service. Colleen lives in Texas with her husband and their three boys.", "~/Images/Authors/87af0318-95ab-43fb-a087-4488e97f98c7.jpg", "Colleen Hoover" },
                    { new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"), "J.K. Rowling is the author of the enduringly popular Harry Potter series, as well as several stand-alone novels and a bestselling crime fiction series. After the idea for Harry Potter came to her on a delayed train journey in 1990, she plotted out and started writing the series of seven books and the first, Harry Potter and the Philosopher’s Stone, was published in the UK in 1997. The series took another ten years to complete, concluding in 2007 with the publication of Harry Potter and the Deathly Hallows. Smash hit movie adaptations followed. The Harry Potter books have now sold over 600 million copies worldwide in 85 languages and been listened to as audiobooks for over one billion hours. To accompany the series, J.K. Rowling wrote three short companion volumes for charity: Quidditch Through the Ages and Fantastic Beasts and Where to Find Them, in aid of Comic Relief and Lumos, and The Tales of Beedle the Bard, in aid of Lumos. Fantastic Beasts and Where to Find Them went on to inspire a new series of films featuring Magizoologist Newt Scamander. Harry’s story as a grown-up was continued in a stage play, Harry Potter and the Cursed Child, which J.K. Rowling wrote with playwright Jack Thorne and director John Tiffany, and which is now playing in multiple locations around the world. In 2020, she returned to publishing for younger children with the fairy tale The Ickabog, the royalties from which she donated to her charitable trust, Volant, to help charities working to alleviate the social effects of the COVID-19 pandemic. Her latest children’s novel, The Christmas Pig, was published in 2021. J.K. Rowling has received many awards and honours for her writing, including the OBE and Companion of Honour, the Hans Christian Andersen Award and a Blue Peter Gold Badge. She supports a wide number of humanitarian causes through Volant, and is the founder of the international children’s care reform charity Lumos. J.K. Rowling lives in Scotland with her family.", "~/Images/Authors/f9bccf28-07ba-472e-aeb8-e5859d30060c.jpg", "J.K. Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AddedDate", "AvailableCount", "Description", "ISBN", "ImagePath", "Language", "PageCount", "Price", "PublicationDate", "PublisherName", "Title" },
                values: new object[,]
                {
                    { new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4168), 4, "This classic biography is the story of seven men—a naturalist, a writer, a lover, a hunter, a ranchman, a soldier, and a politician—who merged at age forty-two to become the youngest President in history. The Rise of Theodore Roosevelt begins at the apex of his international prestige. That was on New Year’s Day, 1907, when TR, who had just won the Nobel Peace Prize, threw open the doors of the White House to the American people and shook 8,150 hands. One visitor remarked afterward, “You go to the White House, you shake hands with Roosevelt and hear him talk—and then you go home to wring the personality out of your clothes.” The rest of this book tells the story of TR’s irresistible rise to power. During the years 1858–1901, Theodore Roosevelt transformed himself from a frail, asthmatic boy into a full-blooded man. Fresh out of Harvard, he simultaneously published a distinguished work of naval history and became the fist-swinging leader of a Republican insurgency in the New York State Assembly. He chased thieves across the Badlands of North Dakota with a copy of Anna Karenina in one hand and a Winchester rifle in the other. Married to his childhood sweetheart in 1886, he became the country squire of Sagamore Hill on Long Island, a flamboyant civil service reformer in Washington, D.C., and a night-stalking police commissioner in New York City. As assistant secretary of the navy, he almost single-handedly brought about the Spanish-American War. After leading “Roosevelt’s Rough Riders” in the famous charge up San Juan Hill, Cuba, he returned home a military hero, and was rewarded with the governorship of New York. In what he called his “spare hours” he fathered six children and wrote fourteen books. By 1901, the man Senator Mark Hanna called “that damned cowboy” was vice president. Seven months later, an assassin’s bullet gave TR the national leadership he had always craved. His is a story so prodigal in its variety, so surprising in its turns of fate, that previous biographers have treated it as a series of haphazard episodes.", "9781400069651", "~/Images/Books/c9a2a08a-8b4c-4603-9abb-af67ec9d92a1.jpg", "English", 960, 40m, new DateTime(2010, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random House", "The Rise of Theodore Roosevelt" },
                    { new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4059), 20, "Marion “Mops” Adamopoulos and her team were trained to clean spaceships. They were absolutely not trained to fight an interplanetary war with the xenocidal Prodryans or to make first contact with the Jynx, a race who might not be as primitive as they seem. But if there’s one lesson Mops and her crew have learned, it’s that things like “training” and “being remotely qualified” are overrated. The war is escalating. (This might be Mops’ fault.) The survival of humanity—those few who weren’t turned to feral, shambling monsters by an alien plague—as well as the fate of all other non-Prodryans, will depend on what Captain Mops and the crew of the EDFS Pufferfish discover on the ringed planet of Tuxatl. But the Jynx on Tuxatl are fighting a war of their own, and their world’s long-buried secrets could be more dangerous than the Prodryans. To make matters worse, Mops is starting to feel a little feral herself…", "9780756412807", "~/Images/Books/e97e05ae-a5ab-4096-b9b8-0c2a3d05d8a9.jpg", "English", 368, 27m, new DateTime(2022, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random House Worlds", "Terminal Peace" },
                    { new Guid("485c54bc-b294-420b-ba53-c4c219af644d"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4178), 6, "Just in time to beat the summer heat, N’ice Cream offers 80 decadent and healthy ice cream recipes made from all-natural, wholesome vegan ingredients like fruits, berries, and plant-based milks and nuts–as the authors say, “no weird stuff.” Get ready to have your ice cream and eat it too. Award-winning Finnish author Virpi and coauthor Tuulia show that making your own ice cream can be easy and good for you at the same time. These recipes can be made with or without an ice cream maker, and include foolproof instant ice creams that can be savored right away. As Tuulia and Virpi say, people deserve to eat goodies without feeling crappy afterwards, and now they can; all the recipes are dairy-free, gluten-free, and refined-sugar-free, and many are nut-free and raw as well. These delicious recipes include creamy ice creams, soft serves, and milkshakes; fresh sorbets and popsicles; party fare like ice cream cakes, sauces, and more. Enjoy light, summery treats like Coconut Water Coolers and Apple Avocado Mint Popsicles, or relish more decadent fare like the Dreamy Chocolate Sundae and Mint Chocolate Ice Cream Sandwiches. The book itself is gorgeously designed with mouth-watering photographs. Perfect for those who want to devour summer treats without guilt, N’ice Cream is about to make your summer a whole lot more delicious.", "9780735210455", "~/Images/Books/46872adf-b4ba-4857-b5fa-028f95f3a233.jpg", "English", 224, 25m, new DateTime(2016, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avery", "N'ice Cream" },
                    { new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4126), 9, "The day after future NBA superstar Chris Paul signed his letter of intent to play college basketball for Wake Forest, he received a world-shattering phone call. His grandfather, Nathaniel \"Papa\" Jones, a pillar of the Winston-Salem community where he owned and operated the first Black-owned service station in North Carolina, was mugged and ultimately died from a heart attack resulting from the assault. His funeral filled the largest church in the county, which held over one thousand people. He was sixty-one years old. The day after burying his grandfather, Chris was coping the best way he knew how: by playing basketball for his high school team. After pouring in shot after shot, his last attempt was an airball purposely flung out of bounds from the foul line before Chris exited the game. The next day, local news headlines declared that he fell six points shy of the statewide single game high school scoring record. But he accomplished exactly what he set out to do: scoring sixty-one points, one for each year of life lived by his grandfather. In Sixty-One, Chris opens up about life beyond basketball and the role his grandfather played in molding him into the man and father he is today. He’ll speak about the foundation of faith and family he built his life upon, what it means to be a positive light within your community and beyond, and the importance of setting the proper example for future generations. Most importantly, Chris will talk about his home, Winston-Salem, and the close-knit family and village that raised him to become one of the most respected leaders in all of sports.", "9781250276711", "~/Images/Books/ca561a7e-3509-4fdf-a22c-869b219d6db0.jpg", "English", 336, 30m, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Martin's Press", "Sixty-One" },
                    { new Guid("5f619a68-3e7f-448e-b352-717915da20e5"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4085), 23, "On January 28, 1742, a ramshackle vessel of patched-together wood and cloth washed up on the coast of Brazil. Inside were thirty emaciated men, barely alive, and they had an extraordinary tale to tell. They were survivors of His Majesty’s Ship the Wager, a British vessel that had left England in 1740 on a secret mission during an imperial war with Spain. While the Wager had been chasing a Spanish treasure-filled galleon known as “the prize of all the oceans,” it had wrecked on a desolate island off the coast of Patagonia. The men, after being marooned for months and facing starvation, built the flimsy craft and sailed for more than a hundred days, traversing nearly 3,000 miles of storm-wracked seas. They were greeted as heroes. But then … six months later, another, even more decrepit craft landed on the coast of Chile. This boat contained just three castaways, and they told a very different story. The thirty sailors who landed in Brazil were not heroes – they were mutineers. The first group responded with countercharges of their own, of a tyrannical and murderous senior officer and his henchmen. It became clear that while stranded on the island the crew had fallen into anarchy, with warring factions fighting for dominion over the barren wilderness. As accusations of treachery and murder flew, the Admiralty convened a court martial to determine who was telling the truth. The stakes were life-and-death—for whomever the court found guilty could hang. The Wager is a grand tale of human behavior at the extremes told by one of our greatest nonfiction writers. Grann’s recreation of the hidden world on a British warship rivals the work of Patrick O’Brian, his portrayal of the castaways’ desperate straits stands up to the classics of survival writing such as The Endurance, and his account of the court martial has the savvy of a Scott Turow thriller. As always with Grann’s work, the incredible twists of the narrative hold the reader spellbound.", "9780385534260", "~/Images/Books/cb63f8e6-b7e7-4ac3-adad-fdf896c65d03.jpg", "English", 352, 30m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubleday", "The Wager" },
                    { new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4136), 3, "As the Order of the Phoenix keeps watch over Harry Potter, troubled times have come to Hogwarts in a year filled with secrets, subterfuge and suspicion. The deliciously dark fifth instalment of Jim Kay's inspired reimagining of J.K. Rowling's classic series is an epic artistic achievement, featuring over 160 illustrations in an astonishing range of visual styles. Now an exciting new collaboration brings together two virtuoso artistic talents, as Kate Greenaway Medal winner Jim Kay is joined by acclaimed guest illustrator Neil Packer, winner of the 2021 BolognaRagazzi Award for non-fiction. Prepare to be enchanted once again as Jim Kay depicts J.K. Rowling's wizarding world with the dazzling artistic alchemy fans around the globe have come to know and love, perfectly complemented by Neil Packer's own unique and eclectic illustrations, skilfully woven into the heart of the story. This is a stunning visual feast of a book, filled with dark magical delights for both fans and new readers alike. Breathtaking scenes, iconic locations and unforgettable characters await inside – Luna Lovegood, Professor Umbridge, Grawp the giant, and many more – as Harry Potter and Dumbledore's Army prepare for the coming battle against Lord Voldemort. Perfect for Potterheads of all ages!", "9781408845684", "~/Images/Books/e721e612-2a18-4ede-b7cb-adbe45a62d91.jpg", "English", 576, 26.99m, new DateTime(2022, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury", "Harry Potter and the Order of the Phoenix (Illustrated Edition)" },
                    { new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4105), 8, "Rebecca Zamolo has managed to foil the Game Master’s plans before, but this time the Game Master has snake-napped Nacho, her good friend Miguel’s pet. No way is Becca going to let the Game Master get away with this dastardly plan. But when the clues lead Becca and her new friends in the direction of the one house in their entire neighborhood that none of them ever want to go near, they know they have no choice but to screw up their courage and dare to investigate, if they want to rescue Nacho. But the problem is that getting into the superspooky house is way easier than getting out. The Game Master is up to their old tricks, and Becca, Matt, Kylie, Frankie, and Miguel are going to have to face their fears and use all their smarts and strengths to solve the puzzles and games and save the day. Mansion Mystery is another action-packed adventure from New York Times bestselling authors and super-sleuthing team Rebecca and Matt Zamolo, stars of the hugely popular Game Master Network.", "9780063025134", "~/Images/Books/caf91194-c199-436c-9a27-adc16135fc3b.jpg", "English", 176, 17.99m, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HarperCollins", "The Game Master: Mansion Mystery" },
                    { new Guid("be157e3e-161f-4764-a782-2bec929bcd94"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4117), 4, "For succulent results every time, nothing is more crucial than understanding the science behind the interaction of food, fire, heat, and smoke. This is the definitive guide to the concepts, methods, equipment, and accessories of barbecue and grilling. The founder and editor of the world's most popular BBQ and grilling website, AmazingRibs.com, and a BBQ Hall of Fame member, “Meathead” Goldwyn applies the latest research to backyard cooking and 118 thoroughly tested recipes. He explains why dry brining is better than wet brining; how marinades really work; why rubs shouldn't have salt in them; how heat and temperature differ; the importance of digital thermometers; why searing doesn't seal in juices; how salt penetrates but spices don't; when charcoal beats gas and when gas beats charcoal; how to calibrate and tune a grill or smoker; how to keep fish from sticking; cooking with logs; the strengths and weaknesses of the new pellet cookers; tricks for rotisserie cooking; why cooking whole animals is a bad idea, which grill grates are best;and why beer-can chicken is a waste of good beer and nowhere close to the best way to cook a bird. Lavishly designed with hundreds of illustrations and full-color photos by the author, this book contains all the sure-fire recipes for traditional American favorites and many more outside-the-box creations. You'll get recipes for all the great regional barbecue sauces; rubs for meats and vegetables; Last Meal Ribs, Simon & Garfunkel Chicken; Schmancy Smoked Salmon; The Ultimate Turkey; Texas Brisket; Perfect Pulled Pork; Sweet & Sour Pork with Mumbo Sauce; Whole Hog; Steakhouse Steaks; Diner Burgers; Prime Rib; Brazilian Short Ribs; Rack Of Lamb Lollipops; Huli-Huli Chicken; Smoked Trout Florida Mullet –Style; Baja Fish Tacos; Lobster, and many more.", "9780544018464", "~/Images/Books/ca561a7e-3509-4fdf-a22c-869b219d6db0.jpg", "English", 400, 35m, new DateTime(2016, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harvest", "Meathead" },
                    { new Guid("c482f838-87c4-4443-b143-62637d4f97e7"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4157), 17, "In the era of WFH, hybrid working and flexible hours, going to the office is no longer what it used to be. Many businesses and organizations, as well as the entire commercial real estate sector, are struggling to address their new workplace dilemmas in the aftermath of the COVID-19 pandemic. With the rise of diverse working practices and new technological innovations, the traditional office space no longer serves the needs of the workforce. And with increasing numbers of staff now comfortable with a degree of working from home, how can companies assess their longer-term workspace needs? This new follow-up edition of Where Is My Office?, fully revised and updated to reflect the true impact of the pandemic on the workplace, highlights some of the bold new frameworks and practical considerations for business leaders, workplace practitioners and those involved in commercial real estate as they navigate the complex post-pandemic working landscape. Authors Chris Kane and Eugenia Anastassiou draw upon their extensive knowledge and experience to investigate the new-found significance of innovative corporate real estate thinking in modern workplaces. Where is My Office?: The Post-Pandemic Edition is a must-read for any business leader or senior manager looking to revitalize their workplace in a post-pandemic environment, and to develop a greater understanding of the beneficial impacts that creative workplace strategies that harness the relationship between people, place, technology, and the environment can have upon their organization's success.", "9781399405171", "~/Images/Books/cf822511-25b1-4ee3-b6e2-ab7721162cfc.jpg", "English", 288, 16m, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury", "Where Is My Office?" },
                    { new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4095), 7, "Charlie Wynwood and Silas Nash have been best friends since they could walk. They've been in love since the age of fourteen. But as of this morning...they are complete strangers. Their first kiss, their first fight, the moment they fell in love...every memory has vanished. Now Charlie and Silas must work together to uncover the truth about what happened to them and why.\r\n\r\nBut the more they learn about the couple they used to be...the more they question why they were ever together to begin with. Forgetting is terrifying, but remembering may be worse.", "9781335004888", "~/Images/Books/e97e05ae-a5ab-4096-b9b8-0c2a3d05d8a9.jpg", "English", 416, 17.99m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canary Street Press", "Never Never" },
                    { new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4146), 14, "Jim Kay's dazzling depiction of J.K. Rowling's wizarding world has won legions of fans since the Illustrated Edition of Harry Potter and the Philosopher's Stone was published in hardback in 2015, becoming a bestseller around the world. This irresistible smaller-format paperback edition of J.K. Rowling's novel brings the magic of Jim Kay's illustration to new readers, with full-colour pictures, French flaps and a handsome poster pull-out at the back of the book. This edition has been beautifully redesigned with selected illustration highlights – the fully illustrated edition is still available in hardback. When a letter arrives for Harry Potter on his eleventh birthday, a decade-old secret is revealed to him that apparently he's the last to know. An incredible adventure is about to begin!", "9781526602381", "~/Images/Books/db1a73c5-360a-43de-8824-3119f8594981.jpg", "English", 256, 10.99m, new DateTime(2018, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloomsbury", "Harry Potter and the Philosopher’s Stone (Illustrated Edition)" },
                    { new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4187), 15, "It was one of the most searing images of the twentieth century: two young boys, two princes, walking behind their mother’s coffin as the world watched in sorrow—and horror. As Princess Diana was laid to rest, billions wondered what Prince William and Prince Harry must be thinking and feeling—and how their lives would play out from that point on. For Harry, this is that story at last. Before losing his mother, twelve-year-old Prince Harry was known as the carefree one, the happy-go-lucky Spare to the more serious Heir. Grief changed everything. He struggled at school, struggled with anger, with loneliness—and, because he blamed the press for his mother’s death, he struggled to accept life in the spotlight. At twenty-one, he joined the British Army. The discipline gave him structure, and two combat tours made him a hero at home. But he soon felt more lost than ever, suffering from post-traumatic stress and prone to crippling panic attacks. Above all, he couldn’t find true love. Then he met Meghan. The world was swept away by the couple’s cinematic romance and rejoiced in their fairy-tale wedding. But from the beginning, Harry and Meghan were preyed upon by the press, subjected to waves of abuse, racism, and lies. Watching his wife suffer, their safety and mental health at risk, Harry saw no other way to prevent the tragedy of history repeating itself but to flee his mother country. Over the centuries, leaving the Royal Family was an act few had dared. The last to try, in fact, had been his mother. . . .  For the first time, Prince Harry tells his own story, chronicling his journey with raw, unflinching honesty. A landmark publication, Spare is full of insight, revelation, self-examination, and hard-won wisdom about the eternal power of love over grief.", "9780593593806", "~/Images/Books/296983b7-6271-4133-ac16-460f54fc3e10.jpg", "English", 416, 36m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random House", "Spare" },
                    { new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"), new DateTime(2023, 7, 8, 3, 22, 16, 241, DateTimeKind.Local).AddTicks(4076), 10, "Deep in Albion’s darkest age, long before once upon a time . . . Heroes are thought to be gone from the land. So why have the bards begun singing of them once more? For Fable newcomers and dedicated fans alike, Blood of Heroes delves into a never-before-glimpsed era, telling the tale of a band of adventurers who come together to defend a kingdom in desperate need. The city of Brightlodge is awash with Heroes from every corner of Albion, all eager for their next quest. When someone tries to burn down the Cock and Bard inn, four Heroes find themselves hastily thrown together, chasing outlaws through sewers, storming a riverboat full of smugglers, and placing their trust in a most unlikely ally. As the beginnings of a deadly plot are revealed, it becomes clear that Heroes have truly arrived—and so have villains. What connects the recent events in Brightlodge to rumors about a malicious ghost and a spate of unsolved deaths in the nearby mining town of Grayrock? Unless Albion’s bravest Heroes can find the answer, the dawn of a new age could be extinguished before it even begins.", "9780345542342", "~/Images/Books/0659ada7-ef7a-4dc6-8977-53bd67540e90.jpg", "English", 336, 16m, new DateTime(2015, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Random House Worlds", "Fable: Blood of Heroes" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("016437a5-5135-43d3-850d-99e150d64e61"), "Mystery" },
                    { new Guid("03f32211-7021-4b30-863d-e81a2766623e"), "Fantasy" },
                    { new Guid("161ec94a-5eca-4fdf-8dd6-485675b4b624"), "Children" },
                    { new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371"), "History" },
                    { new Guid("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed"), "Fiction" },
                    { new Guid("6592963c-fa66-4732-9d43-e7f9efd54556"), "Science" },
                    { new Guid("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e"), "Business & Finance" },
                    { new Guid("b15c4a7f-0b30-4fdf-b664-991785501402"), "Biography" },
                    { new Guid("c577d932-8104-4903-95f3-23d6ab5a25f0"), "Romance" },
                    { new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a"), "Cooking" }
                });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("b2f940f9-91d8-454a-83f8-47e43572fed3"), new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8") },
                    { new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"), new Guid("234e7f45-82e2-4951-b993-0e0360daff8c") },
                    { new Guid("04e87959-6cbb-4622-8206-fa729197d3e7"), new Guid("485c54bc-b294-420b-ba53-c4c219af644d") },
                    { new Guid("9e230070-3689-4b47-83d8-92befb937998"), new Guid("485c54bc-b294-420b-ba53-c4c219af644d") },
                    { new Guid("5014b5d5-0d84-4019-a975-05b3a7b67f9c"), new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f") },
                    { new Guid("784e00df-f751-48d9-a25d-129253723ff3"), new Guid("5f619a68-3e7f-448e-b352-717915da20e5") },
                    { new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"), new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf") },
                    { new Guid("003dceff-365f-4c2f-ba0e-89f1fa58d380"), new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817") },
                    { new Guid("77a7d531-c916-4cec-bac8-0498f0fb060b"), new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817") },
                    { new Guid("433d825d-d80b-4a3f-8894-c14514f04c1c"), new Guid("be157e3e-161f-4764-a782-2bec929bcd94") },
                    { new Guid("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab"), new Guid("be157e3e-161f-4764-a782-2bec929bcd94") },
                    { new Guid("3bca8dab-0014-4e00-9024-bdfe1be5bb24"), new Guid("c482f838-87c4-4443-b143-62637d4f97e7") },
                    { new Guid("0a26d53b-5051-4b2c-a372-10d8cf190747"), new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d") },
                    { new Guid("c96a6380-0d69-4ee6-ab0e-5ea5827370d3"), new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d") },
                    { new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"), new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25") },
                    { new Guid("241d25a6-e7d1-4c66-b080-7845342274f1"), new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc") },
                    { new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"), new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35") }
                });

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"), new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371") },
                    { new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") },
                    { new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"), new Guid("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed") },
                    { new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") },
                    { new Guid("5f619a68-3e7f-448e-b352-717915da20e5"), new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371") },
                    { new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") },
                    { new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"), new Guid("016437a5-5135-43d3-850d-99e150d64e61") },
                    { new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"), new Guid("161ec94a-5eca-4fdf-8dd6-485675b4b624") },
                    { new Guid("be157e3e-161f-4764-a782-2bec929bcd94"), new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a") },
                    { new Guid("c482f838-87c4-4443-b143-62637d4f97e7"), new Guid("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e") },
                    { new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"), new Guid("c577d932-8104-4903-95f3-23d6ab5a25f0") },
                    { new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") },
                    { new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") },
                    { new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("b2f940f9-91d8-454a-83f8-47e43572fed3"), new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"), new Guid("234e7f45-82e2-4951-b993-0e0360daff8c") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("04e87959-6cbb-4622-8206-fa729197d3e7"), new Guid("485c54bc-b294-420b-ba53-c4c219af644d") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("9e230070-3689-4b47-83d8-92befb937998"), new Guid("485c54bc-b294-420b-ba53-c4c219af644d") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("5014b5d5-0d84-4019-a975-05b3a7b67f9c"), new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("784e00df-f751-48d9-a25d-129253723ff3"), new Guid("5f619a68-3e7f-448e-b352-717915da20e5") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"), new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("003dceff-365f-4c2f-ba0e-89f1fa58d380"), new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("77a7d531-c916-4cec-bac8-0498f0fb060b"), new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("433d825d-d80b-4a3f-8894-c14514f04c1c"), new Guid("be157e3e-161f-4764-a782-2bec929bcd94") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab"), new Guid("be157e3e-161f-4764-a782-2bec929bcd94") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("3bca8dab-0014-4e00-9024-bdfe1be5bb24"), new Guid("c482f838-87c4-4443-b143-62637d4f97e7") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("0a26d53b-5051-4b2c-a372-10d8cf190747"), new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("c96a6380-0d69-4ee6-ab0e-5ea5827370d3"), new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"), new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("241d25a6-e7d1-4c66-b080-7845342274f1"), new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"), new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"), new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"), new Guid("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("5f619a68-3e7f-448e-b352-717915da20e5"), new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"), new Guid("016437a5-5135-43d3-850d-99e150d64e61") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"), new Guid("161ec94a-5eca-4fdf-8dd6-485675b4b624") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("be157e3e-161f-4764-a782-2bec929bcd94"), new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("c482f838-87c4-4443-b143-62637d4f97e7"), new Guid("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"), new Guid("c577d932-8104-4903-95f3-23d6ab5a25f0") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"), new Guid("b15c4a7f-0b30-4fdf-b664-991785501402") });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"), new Guid("03f32211-7021-4b30-863d-e81a2766623e") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6592963c-fa66-4732-9d43-e7f9efd54556"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("003dceff-365f-4c2f-ba0e-89f1fa58d380"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("04e87959-6cbb-4622-8206-fa729197d3e7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("0a26d53b-5051-4b2c-a372-10d8cf190747"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("241d25a6-e7d1-4c66-b080-7845342274f1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3bca8dab-0014-4e00-9024-bdfe1be5bb24"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("433d825d-d80b-4a3f-8894-c14514f04c1c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("457c65aa-4a61-44c8-9ef1-a8bcc91c27ab"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5014b5d5-0d84-4019-a975-05b3a7b67f9c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("7345ddb8-f6da-4f88-aedc-783cee9540ec"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("77a7d531-c916-4cec-bac8-0498f0fb060b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("784e00df-f751-48d9-a25d-129253723ff3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("9e230070-3689-4b47-83d8-92befb937998"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b2f940f9-91d8-454a-83f8-47e43572fed3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("c96a6380-0d69-4ee6-ab0e-5ea5827370d3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("e1054010-cccb-4f94-8e10-1611ffd6c692"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("016437a5-5135-43d3-850d-99e150d64e61"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03f32211-7021-4b30-863d-e81a2766623e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("161ec94a-5eca-4fdf-8dd6-485675b4b624"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1dd3c6f1-da15-421e-90a7-d8cbb8449371"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45ba1bb0-d9d5-485a-a6c0-1d691ab334ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8fe24dbf-2cb9-44b3-ac5a-5f759ea51e7e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b15c4a7f-0b30-4fdf-b664-991785501402"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c577d932-8104-4903-95f3-23d6ab5a25f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a"));
        }
    }
}
