using System.Text.Json;
using Library.config;
namespace Library.models;

public class Book
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Plot { get; set; }
    public int Pages { get; set; }

    public Book(string name, string description, string plot, int pages)
    {
        Name = name;
        Description = description;
        Plot = plot;
        Pages = pages;
    }

    public void Save()
    {
        if (!string.IsNullOrEmpty(Name))
        {
            try
            {
                
                if (!Directory.Exists(Config.BooksFolder))
                {
                    Directory.CreateDirectory(Config.BooksFolder);
                }

                
                string filePath = Path.Combine(Config.BooksFolder, $"{Name}.json");

                
                var bookJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

                
                Console.WriteLine(bookJson);

                
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(bookJson);
                }

                Console.WriteLine($"Book '{Name}' saved as JSON successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the book: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Book name cannot be empty.");
        }
    }
}