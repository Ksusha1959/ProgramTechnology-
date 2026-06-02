using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Exceptions;

namespace My_librery.ValueObjects.Validators;

public class titleValidator : IValidator<string>
{

    
    public static int MAX_LENGTH => 50;

  
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);
    }
}
