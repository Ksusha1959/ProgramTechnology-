namespace My_library.Domain.Exceptions;

public class ArgumentNullValueException(string paramName)
    : ArgumentNullException(paramName, $"Аргумент \"{paramName}\" не может быть пустым (null).");
