namespace My_library.Domain.Exceptions;


public class BookNotBelongToUserException(Book book, Reader reader)
    : InvalidOperationException($"Книга '{book.Title}' (ID: {book.Id}) не закреплена за пользователем {reader.Name} (ID читателя: {reader.Id}).")
{
    public Book Book => book;
    public Reader Reader => reader;
}
