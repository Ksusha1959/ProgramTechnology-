using NotesService.ValueObjects.Base;
using NotesService.ValueObjects.Validators;

namespace NotesService.ValueObjects;


public class Tittle(string name) : ValueObject<string>(new TittleValidator(), name);
