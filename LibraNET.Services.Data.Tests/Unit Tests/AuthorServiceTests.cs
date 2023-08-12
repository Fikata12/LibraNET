using LibraNET.Web.ViewModels.Author;
using NUnit.Framework;

namespace LibraNET.Services.Data.Tests.Tests
{
	[TestFixture]
	public class AuthorServiceTests : UnitTestsBase
	{
		private AuthorService authorService;
		private BookService bookService;

		[SetUp]
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
			Assert.That(authors.Count, Is.EqualTo(context.Authors.Count()));
		}

		[Test]
		public async Task AllForDropdownAsync_ShouldReturnAllAuthors()
		{
			// Arrange

			// Act
			var authors = await authorService.AllForDropdownAsync();

			// Assert
			Assert.NotNull(authors);
			Assert.That(authors.Count, Is.EqualTo(context.Authors.Count()));
		}

		[Test]
		public async Task ExistsByIdAsync_Int_ExistingId_ShouldReturnTrue()
		{
			// Arrange
			var existingId = context.Authors.First().Id.ToString();

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
			ICollection<string> existingIds = context.Authors.Select(a => a.Id.ToString()).ToList();

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
			var existingName = context.Authors.First().Name;

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


		[Test]
		public async Task AddAndReturnIdAsync_ShouldReturnIdAndAdd()
		{
			// Arrange
			var author = new AuthorFormModel
			{
				Name = "Name",
				Description = "Description",
				ImageId = Guid.NewGuid().ToString(),
			};
			// Act
			var authorId = await authorService.AddAndReturnIdAsync(author);

			// Assert
			Assert.True(context.Authors.FirstOrDefault(a => a.Id == Guid.Parse(authorId)) != null);
		}

		[Test]
		public async Task GetByIdAsync_ExistingId_ShouldReturnAuthorFormModel()
		{
			// Arrange

			// Act
			var author = await authorService.GetByIdAsync(context.Authors.First().Id.ToString());

			// Assert
			Assert.That(author.Name, Is.EqualTo(context.Authors.First().Name));
			Assert.That(author.Description, Is.EqualTo(context.Authors.First().Description));
			Assert.That(author.ImageId!.ToLower(), Is.EqualTo(context.Authors.First().ImageId.ToString().ToLower()));
		}

		[Test]
		public void GetByIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await authorService.GetByIdAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task EditAsync_ExistingId_ShouldEdit()
		{
			// Arrange
			var author = new AuthorFormModel
			{
				Name = "ChangedName",
				Description = "ChangedDescription",
				ImageId = Guid.NewGuid().ToString(),
			};

			// Act
			await authorService.EditAsync(author, context.Authors.First().Id.ToString());

			// Assert
			Assert.That(context.Authors.First().Name, Is.EqualTo(author.Name));
			Assert.That(context.Authors.First().Description, Is.EqualTo(author.Description));
			Assert.That(context.Authors.First().ImageId.ToString().ToLower(), Is.EqualTo(author.ImageId.ToLower()));
		}

		[Test]
		public void EditAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange
			var author = new AuthorFormModel
			{
				Name = "ChangedName",
				Description = "ChangedDescription",
				ImageId = Guid.NewGuid().ToString(),
			};

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await authorService.EditAsync(author, Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task GetImageIdAsync_ExistingId_ShouldReturnImageId()
		{
			// Arrange

			// Act
			var imageId = await authorService.GetImageIdAsync(context.Authors.First().Id.ToString());

			// Assert
			Assert.That(imageId.ToLower(), Is.EqualTo(context.Authors.First().ImageId.ToString().ToLower()));
		}

		[Test]
		public void GetImageIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await authorService.GetImageIdAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllAuthors()
		{
			// Arrange
			var model = new AllAuthorsViewModel();

			// Act
			var allAuthors = await authorService.AllAsync(model);

			// Assert
			Assert.That(allAuthors.Count, Is.EqualTo(context.Authors.Count()));
		}

		[Test]
		public async Task AllAsync_Fitered_ShouldReturnAllAuthors()
		{
			// Arrange
			var model = new AllAuthorsViewModel
			{
				SearchString = context.Authors.First().Name
			};

			// Act
			var allAuthors = await authorService.AllAsync(model);

			// Assert
			Assert.That(allAuthors.Count, Is.EqualTo(context.Authors.Where(a => a.Name == context.Authors.First().Name).Count()));
		}

		[Test]
		public async Task DeleteAsync_ExistingId_ShouldDeleteAuthor()
		{
			// Arrange

			// Act
			await authorService.DeleteAsync(context.Authors.First().Id.ToString());

			// Assert
			Assert.That(context.Authors.Where(a => !a.IsDeleted).Count(), Is.EqualTo(context.Authors.Count() - 1));
		}

		[Test]
		public void DeleteAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await authorService.DeleteAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task GetDetailsAsync_ExistingId_ShouldReturnAuthorDetailsViewModel()
		{
			// Arrange

			// Act
			var author = await authorService.GetDetailsAsync(context.Authors.First().Id.ToString());

			// Assert
			Assert.That(author.Name, Is.EqualTo(context.Authors.First().Name));
			Assert.That(author.Description, Is.EqualTo(context.Authors.First().Description));
			Assert.That(author.ImageId!.ToLower(), Is.EqualTo(context.Authors.First().ImageId.ToString().ToLower()));
		}

		[Test]
		public void GetDetailsAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await authorService.GetDetailsAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task NameBelongsToIdAsync_ExistingIdAndName_ShouldReturnTrue()
		{
			// Arrange

			// Act
			var exists = await authorService.NameBelongsToIdAsync(context.Authors.First().Name, context.Authors.First().Id.ToString());

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task NameBelongsToIdAsync_NonExistingIdOrName_ShouldReturnFalse()
		{
			// Arrange

			// Act
			var exists = await authorService.NameBelongsToIdAsync("NonExistingName", Guid.NewGuid().ToString());

			// Assert
			Assert.False(exists);
		}
	}
}
