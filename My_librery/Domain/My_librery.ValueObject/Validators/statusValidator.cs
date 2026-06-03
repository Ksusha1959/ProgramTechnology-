using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Exceptions;

namespace My_librery.ValueObjects.Validators;

public class statusValidator : IValidator<string>
{
  
    public static string IN_LIBRARY => "В библиотеке";

    
    public static string AT_READER => "У читателя";

    
    public static string[] ALLOWED_STATUSES => new[] { IN_LIBRARY, AT_READER };

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (!ALLOWED_STATUSES.Contains(value))
            throw new ArgumentInvalidStatusException(nameof(value), value, ALLOWED_STATUSES);
    }
}
