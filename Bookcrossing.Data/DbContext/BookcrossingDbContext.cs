using Bookcrossing.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookcrossing.Data.DbContext
{
    public class BookcrossingDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BookcrossingDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<HistoryOfIssuingBooks> HistoryOfIssuingBooks { get; set; }
    }
}
