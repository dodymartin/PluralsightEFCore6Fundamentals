using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData;

public class PubContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
          "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FirstName = "Rhoda", LastName = "Lerman" });

        var authorList = new Author[]
        {
            new Author { Id = 2, FirstName = "Ruth", LastName = "Ozeki" },
            new Author { Id = 3, FirstName = "Sofia", LastName = "Segovia" },
            new Author { Id = 4, FirstName = "Ursula K.", LastName = "LeGuin" },
            new Author { Id = 5, FirstName = "Hugh", LastName = "Howey" },
            new Author { Id = 6, FirstName = "Isabelle", LastName = "Allende" }
        };
        modelBuilder.Entity<Author>().HasData(authorList);

        //modelBuilder.Entity<Book>().HasData(
        //    new Book { BookId = 1, Title = "Learn Azure in a Month of Lunches", AuthorId = 1 },
        //    new Book { BookId = 2, Title = "Hands-On Azure for Developers", AuthorId = 1 },
        //    new Book { BookId = 3, Title = "Learn Azure in a Month of Lunches", AuthorId = 2 },
        //    new Book { BookId = 4, Title = "Hands-On Azure for Developers", AuthorId = 2 },
        //    new Book { BookId = 5, Title = "Learn Azure in a Month of Lunches", AuthorId = 3 },
        //    new Book { BookId = 6, Title = "Hands-On Azure for Developers", AuthorId = 3 });
    }
}