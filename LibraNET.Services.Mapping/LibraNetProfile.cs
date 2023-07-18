using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Mapping
{
    public class LibraNetProfile : Profile
    {
        public LibraNetProfile()
        {
            CreateMap<Book, HomeBookViewModel>()
                .ForMember(d => d.ImageId, 
                opt => opt.MapFrom(s => s.ImageId.ToString()))
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			// ./Book/All
			CreateMap<Book, AllBooksBookViewModel>()
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.ImageId.ToString()))
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()))
				.ForMember(d => d.Authors,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.Categories,
				opt => opt.MapFrom(s => s.BooksCategories));

			CreateMap<BookAuthor, AllBooksAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Author.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Author.Name));

			CreateMap<BookCategory, CategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Category.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Category.Name));

			CreateMap<Author, AllBooksAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			CreateMap<Category, CategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));
		}
    }
}
