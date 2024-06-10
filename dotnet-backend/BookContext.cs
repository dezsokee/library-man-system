using Microsoft.EntityFrameworkCore;
using webapi;

public class BookContext : DbContext {
    public BookContext(DbContextOptions<BookContext> options) : base(options) {
    }
    
    public DbSet<BookDAL> Books { get; set; }

    public DbSet<LibraryDAL> Libraries { get; set; }

    public DbSet<People> Peoples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<BookDAL>()
            .HasOne(b => b.Library)
            .WithMany(l => l.Books)
            .HasForeignKey(b => b.LibraryId);
    }
}