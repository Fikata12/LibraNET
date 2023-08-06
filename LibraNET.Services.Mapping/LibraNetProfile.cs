using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.Category;
using LibraNET.Web.ViewModels.Comment;
using LibraNET.Web.ViewModels.User;

namespace LibraNET.Services.Mapping
{
	public class LibraNetProfile : Profile
	{
		public LibraNetProfile()
		{
			// Book
			CreateMap<Book, BookViewModel>()
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.ImageId.ToString()))
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()))
				.ForMember(d => d.Authors,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.Categories,
				opt => opt.MapFrom(s => s.BooksCategories));

			CreateMap<BookFormModel, Book>()
				.ForMember(d => d.BooksAuthors,
				opt => opt.MapFrom(s => s.SelectedAuthorsIds))
				.ForMember(d => d.BooksCategories,
				opt => opt.MapFrom(s => s.SelectedCategoriesIds));

			CreateMap<Book, BookFormModel>()
				.ForMember(d => d.SelectedAuthorsIds,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.SelectedCategoriesIds,
				opt => opt.MapFrom(s => s.BooksCategories))
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.ImageId.ToString()));

			CreateMap<Book, BookDetailsViewModel>()
				.ForMember(d => d.OrdersCount,
				opt => opt.MapFrom(s => s.OrdersBooks.Count))
				.ForMember(d => d.Rating,
				opt => opt.MapFrom((s, d, _, context) => s.Ratings.FirstOrDefault(r => r.UserId.ToString() == context.Items["UserId"]?.ToString())?.Value))
				.ForMember(d => d.IsFavorite,
				opt => opt.MapFrom((s, d, _, context) => s.UsersFavouriteBooks.FirstOrDefault(r => r.UserId.ToString() == context.Items["UserId"].ToString() && r.BookId.ToString() == d.Id) != null))
				.ForMember(d => d.Authors,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.Categories,
				opt => opt.MapFrom(s => s.BooksCategories))
				.ForMember(d => d.Comments,
				opt => opt.MapFrom(s => s.Comments.OrderByDescending(c => c.SubmissionTime)));

			// BookAuthor
			CreateMap<BookAuthor, BookAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Author.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Author.Name));

			CreateMap<string, BookAuthor>()
				.ForMember(d => d.AuthorId,
				opt => opt.MapFrom(s => s));

			CreateMap<BookAuthor, string>()
				.ConvertUsing(s => s.AuthorId.ToString());

			// BookCategory
			CreateMap<BookCategory, CategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Category.Id.ToString()))
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => s.Category.Name));

			CreateMap<string, BookCategory>()
				.ForMember(d => d.CategoryId,
				opt => opt.MapFrom(s => s));

			CreateMap<BookCategory, string>()
				.ConvertUsing(s => s.CategoryId.ToString());

			CreateMap<Author, FiltersAuthorViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			CreateMap<Category, FiltersCategoryViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Id.ToString()));

			// Author
			CreateMap<Author, BookAuthorViewModel>();

			CreateMap<AuthorFormModel, Author>();

			CreateMap<Author, AuthorFormModel>();

			CreateMap<Author, AuthorViewModel>();

			// Category
			CreateMap<Category, CategoryViewModel>();

			CreateMap<CategoryFormModel, Category>();

			CreateMap<Category, CategoryFormModel>();

			CreateMap<Category, CategoryViewModel>();

			// ApplicationUser
			CreateMap<ApplicationUser, UserViewModel>();

			// Comment
			CreateMap<Comment, CommentViewModel>()
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

			// Rating
			CreateMap<Rating, int>()
				.ConvertUsing(s => s.Value);
		}
	}
}
