using PublisherData;
using PublisherDomain;
using Microsoft.EntityFrameworkCore;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBook();
GetAuthorsWithBooks();

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach(var author in authors)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName}");
    }
}

void AddAuthor()
{
    var author = new Author { FirstName = "Harper", LastName = "Rush" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Piper", LastName = "Rush" };
    author.Books.Add(new Book
    {
        Title = "Programming Stuff",
        PublishDate = new DateTime(2016, 12, 23)
    });

    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach(var author in authors)
    {
        Console.WriteLine($"{author.FirstName} {author.LastName}");
        foreach(var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}