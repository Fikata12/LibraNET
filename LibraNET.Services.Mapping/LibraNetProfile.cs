using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.Category;

namespace LibraNET.Services.Mapping
{
	public class LibraNetProfile : Profile
	{
		public LibraNetProfile()
		{
			CreateMap<Book, BookViewModel>()
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.ImageId.ToString()))
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()))
				.ForMember(d => d.Authors,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.Categories,
				opt => opt.MapFrom(s => s.BooksCategories));

			CreateMap<BookAuthor, BookAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Author.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Author.Name));

			CreateMap<BookCategory, BookCategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Category.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Category.Name));

			CreateMap<Author, FiltersAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			CreateMap<Category, FiltersCategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			CreateMap<BookFormModel, Book>()
				.ForMember(d => d.BooksAuthors,
				opt => opt.MapFrom(s => s.SelectedAuthorsIds))
				.ForMember(d => d.BooksCategories,
				opt => opt.MapFrom(s => s.SelectedCategoriesIds));

			CreateMap<string, BookAuthor>()
				.ForMember(d => d.AuthorId,
				opt => opt.MapFrom(s => s));

			CreateMap<string, BookCategory>()
				.ForMember(d => d.CategoryId,
				opt => opt.MapFrom(s => s));

			CreateMap<Author, BookAuthorViewModel>();

			CreateMap<Category, BookCategoryViewModel>();
		}
	}
}
