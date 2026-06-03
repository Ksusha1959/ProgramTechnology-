using System;
using My_library.Domain.Base; 

namespace My_library.Domain
{
    public class Librarian : Entity<Guid>
    {
        
        public string Name { get; private set; } = default!;

        
        public Librarian(string name)
            : this(Guid.NewGuid(), name) { }

        
        protected Librarian(Guid id, string name)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("ФИО библиотекаря не может быть пустым", nameof(name));

            Name = name;
        }

       
        public bool UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Новое имя не может быть пустым", nameof(newName));

            if (Name == newName)
                return false;

            Name = newName;
            return true;
        }
    }
}
