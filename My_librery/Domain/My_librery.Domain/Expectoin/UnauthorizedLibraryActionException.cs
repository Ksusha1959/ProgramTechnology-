namespace My_library.Domain.Exceptions;


public class UnauthorizedLibraryActionException<TUser> : InvalidOperationException
    where TUser : class
{
    public Book Book { get; }
    public TUser User { get; }
    public string Action { get; }

    public UnauthorizedActionException(Book book, TUser user, string action)
        : base($"Пользователь {user} не имеет прав на выполнение действия '{action}' над книгой '{book.Title}' (ID книги: {book.Id}).")
    {
        Book = book;
        User = user;
        Action = action;
    }
}
