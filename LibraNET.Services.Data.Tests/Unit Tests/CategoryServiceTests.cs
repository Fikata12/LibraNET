using LibraNET.Web.ViewModels.Category;
using NUnit.Framework;

namespace LibraNET.Services.Data.Tests.Tests
{
	[TestFixture]
	public class CategoryServiceTests : UnitTestsBase
	{
		private BookService bookService;
		private CategoryService categoryService;

		[SetUp]
		public void SetUp()
		{
			bookService = new BookService(context, mapper);
			categoryService = new CategoryService(context, mapper, bookService);
		}

		[Test]
		public async Task AllForFiltersAsync_ShouldReturnAllCategories()
		{
			// Arrange

			// Act
			var categories = await categoryService.AllForFiltersAsync();

			// Assert
			Assert.NotNull(categories);
			Assert.That(categories.Count, Is.EqualTo(context.Categories.Count()));
		}

		[Test]
		public async Task AllForDropdownAsync_ShouldReturnAllAuthors()
		{
			// Arrange

			// Act
			var categories = await categoryService.AllForDropdownAsync();

			// Assert
			Assert.NotNull(categories);
			Assert.That(categories.Count, Is.EqualTo(context.Categories.Count()));
		}

		[Test]
		public async Task ExistsByIdAsync_Int_ExistingId_ShouldReturnTrue()
		{
			// Arrange
			var existingId = context.Categories.First().Id.ToString();

			// Act
			var exists = await categoryService.ExistsByIdAsync(existingId);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_Int_NonExistingId_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingId = Guid.NewGuid().ToString();

			// Act
			var exists = await categoryService.ExistsByIdAsync(nonExistingId);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task ExistsByIdAsync_IntCollection_NonExistingId_ShouldReturnTrue()
		{
			// Arrange
			ICollection<string> existingIds = context.Categories.Select(a => a.Id.ToString()).ToList();

			// Act
			var exists = await categoryService.ExistsByIdAsync(existingIds);

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
			var exists = await categoryService.ExistsByIdAsync(existingIds);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task ExistsByNameAsync_ExistingName_ShouldReturnTrue()
		{
			// Arrange
			var existingName = context.Categories.First().Name;

			// Act
			var exists = await categoryService.ExistsByNameAsync(existingName);

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task ExistsByNameAsync_NonExistingName_ShouldReturnFalse()
		{
			// Arrange
			var nonExistingName = "NonExistingName";

			// Act
			var exists = await categoryService.ExistsByNameAsync(nonExistingName);

			// Assert
			Assert.False(exists);
		}

		[Test]
		public async Task AddAsync_ShouldAdd()
		{
			// Arrange
			var category = new CategoryFormModel
			{
				Name = "CategoryTestName"
			};

			// Act
			await categoryService.AddAsync(category);

			// Assert
			Assert.True(context.Categories.Any(c => c.Name == category.Name));
		}

		[Test]
		public async Task GetByIdAsync_ExistingId_ShouldReturnCategoryFormModel()
		{
			// Arrange

			// Act
			var category = await categoryService.GetByIdAsync(context.Categories.First().Id.ToString());

			// Assert
			Assert.That(category.Name, Is.EqualTo(context.Categories.First().Name));
		}

		[Test]
		public void GetByIdAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await categoryService.GetByIdAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task EditAsync_ExistingId_ShouldEdit()
		{
			// Arrange
			var category = new CategoryFormModel
			{
				Name = "ChangedName"
			};

			// Act
			await categoryService.EditAsync(category, context.Categories.First().Id.ToString());

			// Assert
			Assert.That(context.Categories.First().Name, Is.EqualTo(category.Name));
		}

		[Test]
		public void EditAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange
			var category = new CategoryFormModel
			{
				Name = "ChangedName"
			};

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await categoryService.EditAsync(category, Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task AllAsync_ShouldReturnAllAuthors()
		{
			// Arrange
			var model = new AllCategoriesViewModel();

			// Act
			var allCategories = await categoryService.AllAsync(model);

			// Assert
			Assert.That(allCategories.Count, Is.EqualTo(context.Categories.Count()));
		}

		[Test]
		public async Task AllAsync_Fitered_ShouldReturnAllAuthors()
		{
			// Arrange
			var model = new AllCategoriesViewModel
			{
				SearchString = context.Categories.First().Name
			};

			// Act
			var allCategories = await categoryService.AllAsync(model);

			// Assert
			Assert.That(allCategories.Count(), Is.EqualTo(context.Categories.Where(c => c.Name == context.Categories.First().Name).Count()));
		}

		[Test]
		public async Task DeleteAsync_ExistingId_ShouldDeleteAuthor()
		{
			// Arrange

			// Act
			await categoryService.DeleteAsync(context.Categories.First().Id.ToString());

			// Assert
			Assert.That(context.Categories.Where(c => !c.IsDeleted).Count(), Is.EqualTo(context.Categories.Count() - 1));
		}

		[Test]
		public void DeleteAsync_NonExistingId_ShouldThrowInvalidOperationException()
		{
			// Arrange

			// Act & Assert
			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			await categoryService.DeleteAsync(Guid.NewGuid().ToString()));
		}

		[Test]
		public async Task NameBelongsToIdAsync_ExistingIdAndName_ShouldReturnTrue()
		{
			// Arrange

			// Act
			var exists = await categoryService.NameBelongsToIdAsync(context.Categories.First().Name, context.Categories.First().Id.ToString());

			// Assert
			Assert.True(exists);
		}

		[Test]
		public async Task NameBelongsToIdAsync_NonExistingIdOrName_ShouldReturnFalse()
		{
			// Arrange

			// Act
			var exists = await categoryService.NameBelongsToIdAsync("NonExistingName", Guid.NewGuid().ToString());

			// Assert
			Assert.False(exists);
		}
	}
}
