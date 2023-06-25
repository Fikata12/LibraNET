using LibraNET.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Data
{
    public class LibraNetDbContext : IdentityDbContext
    {
        public LibraNetDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Author> Authors { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Publisher> Publishers { get; set; } = null!;

        public DbSet<Rating> Ratings { get; set; } = null!;

        public DbSet<BookAuthor> BooksAuthors { get; set; } = null!;

        public DbSet<BookCategory> BooksCategories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>()
                .HasKey(e => new { e.BookId, e.RaterId });

            modelBuilder.Entity<BookAuthor>()
                .HasKey(e => new { e.BookId, e.AuthorId });

            modelBuilder.Entity<BookCategory>()
                .HasKey(e => new { e.BookId, e.CategoryId }); 

            base.OnModelCreating(modelBuilder);
        }
    }
}