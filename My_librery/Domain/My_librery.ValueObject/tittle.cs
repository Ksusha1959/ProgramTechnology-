using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Validators;

namespace My_librery.ValueObjects;


public class Tittle(string name) : ValueObject<string>(new TittleValidator(), name);
