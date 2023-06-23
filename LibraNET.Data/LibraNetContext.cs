using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Data
{
    public class LibraNetContext : IdentityDbContext
    {
        public LibraNetContext(DbContextOptions options) : base(options)
        {
        }

        protected LibraNetContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}