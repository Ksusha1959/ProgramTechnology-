namespace My_library.Domain.Exceptions;

// Предполагаем, что у вас есть классы Book и Reader
public class UnauthorizedBookAccessException(Book book, Reader reader)
    : InvalidOperationException($"Читатель {reader.Name} не имеет прав на работу с книгой '{book.Title}' (ID книги: {book.Id}).")
{
    public Book Book => book;
    public Reader Reader => reader;
}
