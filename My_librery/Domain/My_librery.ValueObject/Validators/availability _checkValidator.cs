using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Exceptions;

namespace My_librery.ValueObjects.Validators;

  
    public class  : IValidator<string>
{
    
    public void availability _checkValidator(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));
    }
}
