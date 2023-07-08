using LibraNET.Data.Configurations;
using LibraNET.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Data
{
	public class LibraNetDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public LibraNetDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; } = null!;

		public DbSet<Author> Authors { get; set; } = null!;

		public DbSet<Category> Categories { get; set; } = null!;

		public DbSet<Comment> Comments { get; set; } = null!;

		public DbSet<Rating> Ratings { get; set; } = null!;

		public DbSet<BookAuthor> BooksAuthors { get; set; } = null!;

		public DbSet<BookCategory> BooksCategories { get; set; } = null!;

		public DbSet<UserFavouriteBook> UsersFavouriteBooks { get; set; } = null!;

		public DbSet<Cart> Carts { get; set; } = null!;

		public DbSet<CartBook> CartsBooks { get; set; } = null!;

		public DbSet<Order> Orders { get; set; } = null!;

		public DbSet<OrderBook> OrdersBooks { get; set; } = null!;

		public DbSet<Address> Addresses { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ApplicationUser>()
			.Property(e => e.CartId)
			.IsRequired(false);

			modelBuilder.Entity<ApplicationUser>()
			.Property(e => e.PhoneNumber)
			.IsRequired(false);

			modelBuilder.Entity<ApplicationUser>()
				.HasOne(e => e.Cart)
				.WithOne(e => e.User)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Rating>()
				.HasKey(e => new { e.BookId, e.UserId });

			modelBuilder.Entity<UserFavouriteBook>()
				.HasKey(e => new { e.BookId, e.UserId });

			modelBuilder.Entity<CartBook>()
				.HasKey(e => new { e.CartId, e.BookId });

			modelBuilder.Entity<OrderBook>()
				.HasKey(e => new { e.OrderId, e.BookId });

			modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
			modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
			modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
			modelBuilder.ApplyConfiguration(new BookCategoryEntityConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}