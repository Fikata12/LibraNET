using LibraNET.Data.Models;
using LibraNET.Web.ViewModels.Author;
using NUnit.Framework;

namespace LibraNET.Services.Data.Tests.Tests
{
	[TestFixture]
	public class AuthorServiceTests : UnitTestsBase
	{
		private AuthorService authorService;
		private BookService bookService;

		[OneTimeSetUp]
		public void SetUp()
		{
			bookService = new BookService(context, mapper);
			authorService = new AuthorService(context, mapper, bookService);
		}
		[Test]
		public async Task AllForFiltersAsync_ShouldReturnAllAuthors()
		{
			// Arrange

			// Act
			var authors = await authorService.AllForFiltersAsync();

			// Assert
			Assert.NotNull(authors);
			Assert.That(authors.Count, Is.EqualTo(Authors.Length));
		}

		[Test]
		public async Task AllForDropdownAsync_ShouldReturnAllAuthors()
		{
			// Arrange

			// Act
			var authors = await authorService.AllForDropdownAsync();

			// Assert
			Assert.NotNull(authors);
			Assert.That(authors.Count, Is.EqualTo(Authors.Length));
		}

		[Test]
		public async Task ExistsByIdAsync_Int_ExistingId_ShouldReturnTrue()
		{
			// Arrange
			var existingId = Authors[0].Id.ToString();

			// Act
			var exists = await authorService.ExistsByIdAsync(existingId);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_Int_NonExistingId_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingId = Guid.NewGuid().ToString();

			// Act
			var exists = await authorService.ExistsByIdAsync(nonExistingId);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_IntCollection_NonExistingId_ShouldReturnTrue()
		{
			// Arrange
			ICollection<string> existingIds = Authors.Select(a => a.Id.ToString()).ToList();

			// Act
			var exists = await authorService.ExistsByIdAsync(existingIds);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_IntCollection_NonExistingId_ShouldReturnFalse()
		{
			// Arrange
			ICollection<string> existingIds = new List<string> 
			{ 
				Guid.NewGuid().ToString(), 
				Guid.NewGuid().ToString() 
			};

			// Act
			var exists = await authorService.ExistsByIdAsync(existingIds);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task ExistsByNameAsync_ExistingName_ShouldReturnTrue()
		{
			// Arrange
			var existingName = Authors[0].Name;

			// Act
			var exists = await authorService.ExistsByNameAsync(existingName);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByNameAsync_NonExistingName_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingName = "NonExistingName";

			// Act
			var exists = await authorService.ExistsByNameAsync(nonExistingName);

			// Assert
			Assert.False(exists);
		}
	}
}
