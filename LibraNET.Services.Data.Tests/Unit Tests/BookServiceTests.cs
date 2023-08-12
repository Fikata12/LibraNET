using LibraNET.Web.ViewModels.Book;
using NUnit.Framework;

namespace LibraNET.Services.Data.Tests.Tests
{
	[TestFixture]
	public class BookServiceTests : UnitTestsBase
	{
		private BookService bookService;

		[SetUp]
		public void SetUp()
		{
			bookService = new BookService(context, mapper);
		}

		[Test]
		public async Task LastThreeBooksAsync_ShouldReturnLastThreeBooks()
		{
			// Arrange

			// Act
			var books = await bookService.LastThreeBooksAsync();

			// Assert
			Assert.That(books.Count, Is.EqualTo(3));
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllAuthors()
		{
			// Arrange
			var model = new AllBooksViewModel
			{
				SelectedMaxPrice = (int)Math.Ceiling(context.Books.Max(b => b.Price)),
				SelectedMinPrice = (int)Math.Floor(context.Books.Min(b => b.Price)),
			};

			// Act
			var allBooks = await bookService.AllAsync(model);

			// Assert
			Assert.That(allBooks.Count, Is.EqualTo(context.Books.Count()));
		}

		[Test]
		public async Task MinPriceAsync_ShouldReturnMinPrice()
		{
			// Arrange
			var expected = context.Books.Min(b => b.Price);

			// Act
			var actual = await bookService.MinPriceAsync();

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public async Task MaxPriceAsync_ShouldReturnMaxPrice()
		{
			// Arrange
			var expected = context.Books.Max(b => b.Price);

			// Act
			var actual = await bookService.MaxPriceAsync();

			// Assert
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public async Task AddAndReturnIdAsync_ShouldReturnIdAndAdd()
		{
			// Arrange
			var author = new BookFormModel
			{
				Title = "ExpectedTitle",
				ISBN = "1412165376426",
				PublicationDate = DateTime.Now,
				Description = "ExpectedDescription",
				PageCount = 100,
				Language = "English",
				ImageId = Guid.NewGuid().ToString(),
				Price = 10,
				AvailableCount = 10,
				PublisherName = "ExpectedPublisher"
			};
			// Act
			var bookId = await bookService.AddAndReturnIdAsync(author);

			// Assert
			Assert.True(context.Books.FirstOrDefault(b => b.Id == Guid.Parse(bookId)) != null);
		}

		[Test]
		public async Task GetByIdAsync_ExistingId_ShouldReturnBookFormModel()
		{
			// Arrange

			// Act
			var book = await bookService.GetByIdAsync(context.Books.First().Id.ToString());

			// Assert
			Assert.That(book.Title, Is.EqualTo(context.Books.First().Title));
			Assert.That(book.ISBN, Is.EqualTo(context.Books.First().ISBN));
			Assert.That(book.PublicationDate, Is.EqualTo(context.Books.First().PublicationDate));
			Assert.That(book.Description, Is.EqualTo(context.Books.First().Description));
			Assert.That(book.PageCount, Is.EqualTo(context.Books.First().PageCount));
			Assert.That(book.Language, Is.EqualTo(context.Books.First().Language));
			Assert.That(book.ImageId!.ToLower(), Is.EqualTo(context.Books.First().ImageId.ToString().ToLower()));
			Assert.That(book.Price, Is.EqualTo(context.Books.First().Price));
			Assert.That(book.AvailableCount, Is.EqualTo(context.Books.First().AvailableCount));
			Assert.That(book.PublisherName, Is.EqualTo(context.Books.First().PublisherName));
		}

		[Test]
		public void GetByIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.GetByIdAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task EditAsync_ExistingId_ShouldEdit()
		{
			// Arrange
			var selectedAuthorIds = context.Authors
				.Take(2)
				.Select(a => a.Id.ToString())
				.ToList();

			var selectedCategoryIds = context.Categories
				.Take(2)
				.Select(c => c.Id.ToString())
				.ToList();

			var book = new BookFormModel
			{
				Title = "ExpectedTitle",
				ISBN = "1412165376426",
				PublicationDate = DateTime.Now,
				Description = "ExpectedDescription",
				PageCount = 100,
				Language = "English",
				ImageId = Guid.NewGuid().ToString(),
				Price = 10,
				AvailableCount = 10,
				PublisherName = "ExpectedPublisher",
				SelectedAuthorsIds = selectedAuthorIds,
				SelectedCategoriesIds = selectedCategoryIds
			};

			// Act
			await bookService.EditAsync(book, context.Books.First().Id.ToString());

			// Assert
			Assert.Multiple(() =>
			{
				Assert.That(context.Books.First().Title, Is.EqualTo(book.Title));
				Assert.That(context.Books.First().ISBN, Is.EqualTo(book.ISBN));
				Assert.That(context.Books.First().PublicationDate, Is.EqualTo(book.PublicationDate));
				Assert.That(context.Books.First().Description, Is.EqualTo(book.Description));
				Assert.That(context.Books.First().PageCount, Is.EqualTo(book.PageCount));
				Assert.That(context.Books.First().Language, Is.EqualTo(book.Language));
				Assert.That(context.Books.First().ImageId.ToString().ToLower(), Is.EqualTo(book.ImageId!.ToLower()));
				Assert.That(context.Books.First().Price, Is.EqualTo(book.Price));
				Assert.That(context.Books.First().AvailableCount, Is.EqualTo(book.AvailableCount));
				Assert.That(context.Books.First().PublisherName, Is.EqualTo(book.PublisherName));
				Assert.That(context.Books.First().BooksCategories.Count, Is.EqualTo(book.SelectedCategoriesIds.Count));
				Assert.That(context.Books.First().BooksAuthors.Count, Is.EqualTo(book.SelectedAuthorsIds.Count));
			});
		}

		[Test]
		public void EditAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange
			var selectedAuthorIds = context.Authors
				.Take(2)
				.Select(a => a.Id.ToString())
				.ToList();

			var selectedCategoryIds = context.Categories
				.Take(2)
				.Select(c => c.Id.ToString())
				.ToList();

			var book = new BookFormModel
			{
				Title = "ExpectedTitle",
				ISBN = "1412165376426",
				PublicationDate = DateTime.Now,
				Description = "ExpectedDescription",
				PageCount = 100,
				Language = "English",
				ImageId = Guid.NewGuid().ToString(),
				Price = 10,
				AvailableCount = 10,
				PublisherName = "ExpectedPublisher",
				SelectedAuthorsIds = selectedAuthorIds,
				SelectedCategoriesIds = selectedCategoryIds
			};

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.EditAsync(book, Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task GetImageIdAsync_ExistingId_ShouldReturnImageId()
		{
			// Arrange

			// Act
			var imageId = await bookService.GetImageIdAsync(context.Books.First().Id.ToString());

			// Assert
			Assert.That(imageId.ToLower(), Is.EqualTo(context.Books.First().ImageId.ToString().ToLower()));
		}

		[Test]
		public void GetImageIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.GetImageIdAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task DeleteAsync_ExistingId_ShouldDeleteBook()
		{
			// Arrange

			// Act
			await bookService.DeleteAsync(context.Books.First().Id.ToString());

			// Assert
			Assert.That(context.Books.Where(a => !a.IsDeleted).Count(), Is.EqualTo(context.Books.Count() - 1));
			Assert.That(context.Books.First().CartsBooks.Count, Is.EqualTo(0));
			Assert.That(context.Books.First().UsersFavouriteBooks.Count, Is.EqualTo(0));
		}

		[Test]
		public void DeleteAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.DeleteAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task ExistsByIdAsync_ExistingId_ShouldReturnTrue()
		{
			// Arrange
			var existingId = context.Books.First().Id.ToString();

			// Act
			var exists = await bookService.ExistsByIdAsync(existingId);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_NonExistingId_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingId = Guid.NewGuid().ToString();

			// Act
			var exists = await bookService.ExistsByIdAsync(nonExistingId);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task ExistsByIsbnAsync_ExistingIsbn_ShouldReturnTrue()
		{
			// Arrange
			var existingIsbn = context.Books.First().ISBN!.ToString();

			// Act
			var exists = await bookService.ExistsByIsbnAsync(existingIsbn);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByIsbnAsync_NonExistingIsbn_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingIsbn = "2326326323425";

			// Act
			var exists = await bookService.ExistsByIsbnAsync(nonExistingIsbn);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public void GetByIdAsync_Details_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.GetByIdAsync(Guid.NewGuid().ToString(), context.Users.First().Id.ToString()));
		}

		[Test]
		public async Task AvailableCountAsync_ExistingId_ShouldReturnAvailableCount()
		{
			// Arrange

			// Act
			var availableCount = await bookService.AvailableCountAsync(context.Books.First().Id.ToString());

			// Assert
			Assert.That(context.Books.First().AvailableCount, Is.EqualTo(availableCount));
		}

		[Test]
		public void AvailableCountAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await bookService.AvailableCountAsync(Guid.NewGuid().ToString()));
		}
	}
}
