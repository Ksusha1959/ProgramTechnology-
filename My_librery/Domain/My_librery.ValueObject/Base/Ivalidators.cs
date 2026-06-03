namespace My_librery.ValueObjects.Base;

public interface IValidator<T>
{
    
    void Validate(T value);
}
