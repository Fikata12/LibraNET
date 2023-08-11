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

		public Author[] Authors { get; set; }
		public Category[] Categories { get; set; }

		[OneTimeSetUp]
		public void OneTimeSetUpBase()
		{
			context = DatabaseMock.Instance;
			mapper = AutoMapperMock.Instance;
			SeedDatabase();
		}
		[OneTimeTearDown]
		public void OneTimeTearDownBase()
		{
			context.Dispose();
		}
		[TearDown]
		public void TearDownBase()
		{

		}

		void SeedDatabase()
		{
			Authors = new Author[]
			{
				new Author
				{
				Id = Guid.NewGuid(),
				Name = "Test Name1",
				Description = "Test Description1",
				ImageId =  Guid.NewGuid()
				},
				new Author
				{
				Id = Guid.NewGuid(),
				Name = "Test Name2",
				Description = "Test Description2",
				ImageId = Guid.NewGuid()
				}
			};

			Categories = new Category[]
			{
				new Category
				{
				Id = Guid.NewGuid(),
				Name = "Test Name1",
				},
				new Category
				{
				Id = Guid.NewGuid(),
				Name = "Test Name2"
				}
			};

			context.Categories.AddRange(Categories);
			context.Authors.AddRange(Authors);

			context.SaveChanges();
		}
	}
}
