using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Exceptions;

namespace My_librery.ValueObjects.Validators;

   
    public class librarian_nameValidator : IValidator<string>
{
    
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));
    }
}
