using System.Text.Json;
using Library.config;
using Library.models;

namespace Library.utils;

public sealed class BookReader
{
    
    private static readonly Lazy<BookReader> instance = new Lazy<BookReader>(() => new BookReader());

    
    private BookReader() { }

    
    public static BookReader Instance
    {
        get
        {
            return instance.Value;
        }
    }

    
    public List<Book> GetAllBooks()
    {
        List<Book> books = new List<Book>();

        
        if (Directory.Exists(Config.BooksFolder))
        {
            
            var bookFiles = Directory.GetFiles(Config.BooksFolder, "*.json");

            foreach (var file in bookFiles)
            {
                try
                {
                    
                    string bookJson = File.ReadAllText(file);

                    
                    Book? book = JsonSerializer.Deserialize<Book>(bookJson);

                    
                    if (book != null)
                    {
                        books.Add(book);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file {file}: {ex.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine("Books folder does not exist.");
        }

        return books;
    }
}
