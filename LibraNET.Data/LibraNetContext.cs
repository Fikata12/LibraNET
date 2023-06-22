using Microsoft.EntityFrameworkCore;

namespace LibraNET.Data
{
    public class LibraNetContext : DbContext
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