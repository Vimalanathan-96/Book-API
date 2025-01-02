using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Publisher).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.AuthorLastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.AuthorFirstName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.Price).HasColumnType("decimal(18,2)");
        }
    }
}
