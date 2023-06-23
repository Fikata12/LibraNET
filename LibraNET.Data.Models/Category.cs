﻿using System.ComponentModel.DataAnnotations;
using static LibraNET.Common.ValidationConstants.Category;

namespace LibraNET.Data.Models
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
            BooksCategories = new List<BookCategory>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;


        public virtual ICollection<BookCategory> BooksCategories { get; set; }
    }
}