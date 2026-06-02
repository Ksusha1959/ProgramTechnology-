using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Validators;

namespace My_librery.ValueObjects;


public class status(string name) : ValueObject<string>(new statusValidator(), name);
