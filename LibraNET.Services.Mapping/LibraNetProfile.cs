﻿using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels.Author;
using LibraNET.Web.ViewModels.Book;
using LibraNET.Web.ViewModels.Category;
using LibraNET.Web.ViewModels.User;

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

			CreateMap<Book, BookFormModel>()
				.ForMember(d => d.SelectedAuthorsIds,
				opt => opt.MapFrom(s => s.BooksAuthors))
				.ForMember(d => d.SelectedCategoriesIds,
				opt => opt.MapFrom(s => s.BooksCategories))
				.ForMember(d => d.ImageId,
				opt => opt.MapFrom(s => s.ImageId.ToString()));

			CreateMap<BookAuthor, string>()
				.ConvertUsing(s => s.AuthorId.ToString());

			CreateMap<BookCategory, string>()
				.ConvertUsing(s => s.CategoryId.ToString());

			CreateMap<AuthorFormModel, Author>();
			CreateMap<Author, AuthorFormModel>();

			CreateMap<CategoryFormModel, Category>();
			CreateMap<Category, CategoryFormModel>();

			CreateMap<ApplicationUser, UserViewModel>();
        }
	}
}
