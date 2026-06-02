using NotesService.ValueObjects.Base;
using NotesService.ValueObjects.Validators;

namespace NotesService.ValueObjects;


public class availability_check(string name) : ValueObject<string>(new availability_checkValidator(), name);
