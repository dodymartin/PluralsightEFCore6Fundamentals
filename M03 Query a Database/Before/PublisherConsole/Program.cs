// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

var _context = new PubContext();

//GetAuthors();

QueryFilters();

void QueryFilters()
{
    var author = _context.Authors.Find(2);
    var authors = _context.Authors.Where(s => s.FirstName == "Cody").ToList();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
