using My_librery.ValueObjects.Base;
using My_librery.ValueObjects.Validators;

namespace My_librery.ValueObjects;

/// <summary>
/// Represents type of the entity's username.
/// </summary>
/// <param name="name">The username of the entity.</param>
public class librarman_name(string name) : ValueObject<string>(new librarman_nameValidator(), name);
