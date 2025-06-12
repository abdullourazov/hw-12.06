using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookEditor> BookEditors { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        modelBuilder.Entity<Author>()
            .HasMany(a => a.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookEditors)
            .WithOne(be => be.Book)
            .HasForeignKey(be => be.Isbn);

        modelBuilder.Entity<Editor>()
            .HasMany(e => e.BookEditors)
            .WithOne(be => be.Editor)
            .HasForeignKey(be => be.EditorId);

        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublishedId);
    }



}
