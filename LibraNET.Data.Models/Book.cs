﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LibraNET.Common.ValidationConstants.Book;

namespace LibraNET.Data.Models
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid();
            BooksAuthors = new List<BookAuthor>();
            BooksCategories = new List<BookCategory>();
            UsersFavouriteBooks = new List<UserFavouriteBook>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            CartsBooks = new List<CartBook>();
            OrdersBooks = new List<OrderBook>();
            AddedDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(ISBNLength)]
        public string? ISBN { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

		[Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public int PageCount { get; set; }

        [Required]
        [MaxLength(LanguageMaxLength)]
        public string Language { get; set; } = null!;

        [Required]
        public Guid ImageId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AvailableCount { get; set; }

        [Required]
        [MaxLength(PublisherNameMaxLength)]
        public string PublisherName { get; set; } = null!;

		[Required]
		public DateTime AddedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }


		public virtual ICollection<BookAuthor> BooksAuthors { get; set; }
        public virtual ICollection<BookCategory> BooksCategories { get; set; }
        public virtual ICollection<UserFavouriteBook> UsersFavouriteBooks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<CartBook> CartsBooks { get; set; }
		public virtual ICollection<OrderBook> OrdersBooks { get; set; }
    }
}