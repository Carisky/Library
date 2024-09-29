using Faker;
using Library.models;
using System.Linq;

namespace Library.utils;

public static class BookFactory
{
    
    public static Book CreateRandomBook()
    {
        
        string name = Faker.Lorem.Sentence(3); 
        string description = Faker.Lorem.Paragraph(); 
        string plot = Faker.Lorem.Paragraphs(2).Aggregate((p1, p2) => p1 + "\n\n" + p2); 

        
        int wordCount = plot.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

        
        int pages = (int)Math.Ceiling(wordCount / 25.0);

        
        return new Book(name, description, plot, pages);
    }

    
    public static List<Book> CreateRandomBooks(int count)
    {
        List<Book> books = new List<Book>();

        for (int i = 0; i < count; i++)
        {
            books.Add(CreateRandomBook());
        }

        return books;
    }
}
