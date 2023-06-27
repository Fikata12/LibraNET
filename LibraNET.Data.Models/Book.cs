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
            AddedDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLenght)]
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
        public string ImageURL { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Publisher))]
        public Guid PublisherId { get; set; }

		[Required]
		public DateTime AddedDate { get; set; }


		public virtual ICollection<BookAuthor> BooksAuthors { get; set; }
        public virtual ICollection<BookCategory> BooksCategories { get; set; }
        public virtual ICollection<UserFavouriteBook> UsersFavouriteBooks { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual Publisher Publisher { get; set; } = null!;
    }
}