using AutoMapper;
using LibraNET.Data;
using LibraNET.Data.Models;
using LibraNET.Services.Data.Tests.Mocks;
using NUnit.Framework;

namespace LibraNET.Services.Data.Tests.Tests
{
	public class UnitTestsBase
	{
		protected LibraNetDbContext context;
		protected IMapper mapper;

		private Author[] Authors { get; set; }
		private Book[] Books { get; set; }
		private Category[] Categories { get; set; }
		private Cart[] Carts { get; set; }
		private ApplicationUser[] Users { get; set; }
		private BookAuthor[] BooksAuthors { get; set; }
		private BookCategory[] BooksCategories { get; set; }
		private CartBook[] CartsBooks { get; set; }
		private UserFavouriteBook[] UsersFavouriteBooks { get; set; }

		[SetUp]
		public void OneTimeSetUpBase()
		{
			context = DatabaseMock.Instance;
			mapper = AutoMapperMock.Instance;
			SeedDatabase();
		}
		[TearDown]
		public void OneTimeTearDownBase()
		{
			context.Dispose();
		}

		void SeedDatabase()
		{
			Authors = new Author[]
			{
				new Author
				{
				Id = Guid.Parse("e4d69c53-b0f8-45e1-b3ba-50cd3c02a670"),
				Name = "Author1",
				Description = "AuthorDescription1",
				ImageId = Guid.NewGuid()
				},
				new Author
				{
				Id = Guid.Parse("264a0189-56c0-454b-8159-f7baa5dc2b74"),
				Name = "Author2",
				Description = "AuthorDescription2",
				ImageId = Guid.NewGuid()
				}
			};

			Books = new Book[]
			{
				new Book
				{
				Id = Guid.Parse("d4f3e419-61aa-44ff-8911-30c3c0cf332c"),
				Title = "Title1",
				ISBN = "1111111111111",
				PublicationDate = DateTime.Now,
				Description = "BookDescription1",
				PageCount = 100,
				Language = "English",
				ImageId = Guid.Parse("e786a251-241a-4e80-a808-5b4ec0a9c0ff"),
				Price = 10,
				AvailableCount = 10,
				PublisherName = "Publisher1",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("71fb442f-c877-4921-9ce5-bfeb89ece3d7"),
				Title = "Title2",
				ISBN = "2222222222222",
				PublicationDate = DateTime.Now.AddDays(1),
				Description = "BookDescription2",
				PageCount = 200,
				Language = "Bulgarian",
				ImageId = Guid.Parse("2f0ada73-4916-4525-8c9e-b9e1cbe1da8f"),
				Price = 20,
				AvailableCount = 20,
				PublisherName = "Publisher2",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("91582a12-996c-4515-b24c-8bfda772df3c"),
				Title = "Title3",
				ISBN = "3333333333333",
				PublicationDate = DateTime.Now.AddDays(2),
				Description = "BookDescription3",
				PageCount = 300,
				Language = "Greek",
				ImageId = Guid.Parse("11403c4a-c7de-48f2-883c-b7bc413d63c4"),
				Price = 30,
				AvailableCount = 30,
				PublisherName = "Publisher3",
				AddedDate = DateTime.Now
				},
				new Book
				{
				Id = Guid.Parse("78431ff3-3d46-4e3c-8e58-f31b8163490d"),
				Title = "Title4",
				ISBN = "4444444444444",
				PublicationDate = DateTime.Now.AddDays(3),
				Description = "BookDescription4",
				PageCount = 400,
				Language = "Serbian",
				ImageId = Guid.Parse("9baa6427-cad0-4dc5-a394-dea32aeba911"),
				Price = 40,
				AvailableCount = 40,
				PublisherName = "Publisher4",
				AddedDate = DateTime.Now
				}
			};

			Users = new ApplicationUser[]
			{
				new ApplicationUser
				{
					Id = Guid.Parse("6f844e96-0d20-45ad-84d6-a6e9e694cdee"),
					FirstName = "Test",
					LastName = "Test",
					PhoneNumber = "0876666666",
					CartId = Guid.Parse("96a5d312-e53c-4b11-a5c4-6e3ced72d201")
				}
			};

			Carts = new Cart[]
			{
				new Cart
				{
					Id = Guid.Parse("96a5d312-e53c-4b11-a5c4-6e3ced72d201"),
					UserId = Guid.Parse("6f844e96-0d20-45ad-84d6-a6e9e694cdee")
				}
			};

			Categories = new Category[]
			{
				new Category
				{
				Id = Guid.Parse("c4f5728e-719e-49b7-8d40-92b7698b8f26"),
				Name = "CategoryName1",
				},
				new Category
				{
				Id = Guid.Parse("e7f39520-69d1-4711-88ee-c285874c7103"),
				Name = "CategoryName2"
				}
			};

			BooksAuthors = new BookAuthor[]
			{
				new BookAuthor
				{
					BookId = Books[0].Id,
					AuthorId = Authors[0].Id,
				},
				new BookAuthor
				{
					BookId = Books[0].Id,
					AuthorId = Authors[1].Id,
				},
				new BookAuthor
				{
					BookId = Books[1].Id,
					AuthorId = Authors[1].Id,
				},
			};

			BooksCategories = new BookCategory[]
			{
				new BookCategory
				{
					BookId = Books[0].Id,
					CategoryId = Categories[0].Id,
				},
				new BookCategory
				{
					BookId = Books[0].Id,
					CategoryId = Categories[1].Id,
				},
				new BookCategory
				{
					BookId = Books[1].Id,
					CategoryId = Categories[1].Id,
				},
			};

			CartsBooks = new CartBook[]
			{
				new CartBook
				{
					CartId = Carts[0].Id,
					BookId = Books[0].Id,
					BookCount = 1,
				},
				new CartBook
				{
					CartId = Carts[0].Id,
					BookId = Books[1].Id,
					BookCount = 2,
				},
			};

			UsersFavouriteBooks = new UserFavouriteBook[]
			{
				new UserFavouriteBook
				{
					UserId = Users[0].Id,
					BookId = Books[0].Id,
				},
				new UserFavouriteBook
				{
					UserId = Users[0].Id,
					BookId = Books[1].Id,
				},
			};

			context.Authors.AddRange(Authors);
			context.Books.AddRange(Books);
			context.Users.AddRange(Users);
			context.Carts.AddRange(Carts);
			context.Categories.AddRange(Categories);
			context.BooksAuthors.AddRange(BooksAuthors);
			context.BooksCategories.AddRange(BooksCategories);
			context.CartsBooks.AddRange(CartsBooks);
			context.UsersFavouriteBooks.AddRange(UsersFavouriteBooks);

			context.SaveChanges();
		}
	}
}
