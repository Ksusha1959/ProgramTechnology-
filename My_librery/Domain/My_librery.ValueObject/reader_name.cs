using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Validators;

namespace My_librery.ValueObjects;

public class reader_name(string name) : ValueObject<string>(new reader_nameValidator(), name);
