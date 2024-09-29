using Library.models;
using Library.utils;

List<Book> randomBooks = BookFactory.CreateRandomBooks(5);
foreach (var item in randomBooks)
{
    item.Save();
}

var bookReader = BookReader.Instance;
List<Book> allBooks = bookReader.GetAllBooks();

foreach (var book in allBooks)
{
    Console.WriteLine($"Book: {book.Name}, Pages: {book.Pages}");
}
