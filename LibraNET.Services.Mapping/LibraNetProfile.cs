using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.Cart;
using LibraNET.Web.ViewModels.Category;
using LibraNET.Web.ViewModels.Comment;
using LibraNET.Web.ViewModels.Order;
using LibraNET.Web.ViewModels.User;
using System.Globalization;

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

			CreateMap<Book, AdminBookViewModel>();

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
				opt => opt.MapFrom(s => s.OrdersBooks.Sum(ob => ob.BookCount)))
				.ForMember(d => d.Rating,
				opt => opt.MapFrom((s, d, _, context) => s.Ratings.FirstOrDefault(r => r.UserId.ToString() == context.Items["UserId"]?.ToString())?.Value))
				.ForMember(d => d.IsFavorite,
				opt => opt.MapFrom((s, d, _, context) => s.UsersFavouriteBooks.FirstOrDefault(ufb => ufb.UserId.ToString().ToLower() == context.Items["UserId"]?.ToString() && ufb.BookId.ToString().ToLower() == d.Id) != null))
				.ForMember(d => d.Authors,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.Categories,
				opt => opt.MapFrom(s => s.BooksCategories))
				.ForMember(d => d.Comments,
				opt => opt.MapFrom(s => s.Comments.OrderByDescending(c => c.SubmissionTime)))
				.ForMember(d => d.Quantity,
				opt => opt.MapFrom(s => s.CartsBooks.FirstOrDefault(cb => cb.BookId.Equals(s.Id)) == null ? 1 : s.CartsBooks.FirstOrDefault(cb => cb.BookId.Equals(s.Id))!.BookCount));

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

			CreateMap<Author, AdminAuthorViewModel>();

            CreateMap<Author, AuthorDetailsViewModel>();

			// Category
			CreateMap<Category, CategoryViewModel>();

			CreateMap<CategoryFormModel, Category>();

			CreateMap<Category, CategoryFormModel>();

			CreateMap<Category, CategoryViewModel>();

			// ApplicationUser
			CreateMap<ApplicationUser, UserViewModel>();

			CreateMap<ApplicationUser, AccountViewModel>()
				.ForMember(d => d.Orders,
				opt => opt.MapFrom(s => s.Orders.OrderByDescending(o => o.Date)));

			// Comment
			CreateMap<Comment, CommentViewModel>()
				.ForMember(d => d.Name,
				opt => opt.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

			// Rating
			CreateMap<Rating, int>()
				.ConvertUsing(s => s.Value);

			// CartBook
			CreateMap<CartBook, BookCartViewModel>()
				.ForMember(d => d.TotalPrice,
				opt => opt.MapFrom(s => s.Book.Price * s.BookCount))
				.ForMember(d => d.Title,
				opt => opt.MapFrom(s => s.Book.Title))
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.Book.Id))
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.Book.ImageId))
				.ForMember(d => d.Quantity,
				opt => opt.MapFrom(s => s.BookCount))
				.ForMember(d => d.AvailableCount,
				opt => opt.MapFrom(s => s.Book.AvailableCount));

			//Order
			CreateMap<CheckoutViewModel, Order>()
				.ForMember(d => d.RecipientName,
				opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
				.ForMember(d => d.UserId,
				opt => opt.MapFrom((s, d, _, context) => context.Items["UserId"]!.ToString()));

			CreateMap<Order, OrderDetailsViewModel>()
				.ForMember(d => d.Books,
				opt => opt.MapFrom(s => s.OrdersBooks));

			CreateMap<Order, AdminOrderViewModel>()
				.ForMember(d => d.Email,
				opt => opt.MapFrom(s => s.User.Email))
				.ForMember(d => d.Date,
				opt => opt.MapFrom(s => s.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.Price,
                opt => opt.MapFrom(s => s.OrdersBooks.Sum(ob => ob.Book.Price).ToString("f2")))
                .ForMember(d => d.Date,
                opt => opt.MapFrom(s => s.Date.ToString("f")));


            // OrderBook
            CreateMap<CartBook, OrderBook>();

			CreateMap<OrderBook, BookOrderViewModel>()
				.ForMember(d => d.Id,
				opt => opt.MapFrom(s => s.BookId))
				.ForMember(d => d.Title,
				opt => opt.MapFrom(s => s.Book.Title))
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.Book.ImageId))
				.ForMember(d => d.Quantity,
				opt => opt.MapFrom(s => s.BookCount))
				.ForMember(d => d.TotalPrice,
				opt => opt.MapFrom(s => s.Book.Price * s.BookCount));
		}
	}
}
