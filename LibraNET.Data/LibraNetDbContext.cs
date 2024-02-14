using LibraNET.Data.Configurations;
using LibraNET.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Data
{
	public class LibraNetDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, 
		IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>, 
		IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
	{
		bool seed;

		public LibraNetDbContext(DbContextOptions options, bool seed = true) : base(options)
		{
			if (!Database.IsRelational())
			{
				Database.EnsureCreated();
			}

			this.seed = seed;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

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

			modelBuilder.Entity<BookAuthor>()
				.HasKey(e => new { e.BookId, e.AuthorId });

			modelBuilder.Entity<BookCategory>()
				.HasKey(e => new { e.BookId, e.CategoryId });

			modelBuilder.Entity<ApplicationUser>()
				.HasMany(e => e.UsersRoles)
				.WithOne(e => e.User)
				.HasForeignKey(ur => ur.UserId)
				.IsRequired();

			modelBuilder.Entity<ApplicationRole>()
				.HasMany(e => e.UsersRoles)
				.WithOne(e => e.Role)
				.HasForeignKey(ur => ur.RoleId)
				.IsRequired();

			modelBuilder.Entity<ApplicationUserRole>()
				.HasOne(e => e.Role)
				.WithMany(e => e.UsersRoles)
				.HasForeignKey(ur => ur.RoleId)
				.IsRequired();

			modelBuilder.Entity<ApplicationUserRole>()
				.HasOne(e => e.User)
				.WithMany(e => e.UsersRoles)
				.HasForeignKey(ur => ur.UserId)
				.IsRequired();

			if (seed)
			{
				modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
				modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
				modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
				modelBuilder.ApplyConfiguration(new BookAuthorEntityConfiguration());
				modelBuilder.ApplyConfiguration(new BookCategoryEntityConfiguration());
			}
		}
	}
}