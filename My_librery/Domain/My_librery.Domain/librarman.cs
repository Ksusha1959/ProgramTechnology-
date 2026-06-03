using System;
using My_library.Domain.Base; 

namespace My_library.Domain
{
    public class Librarian : Entity<Guid>
    {
        // Свойство Name соответствует полю 'name' (ФИО библиотекаря) из вашей схемы
        public string Name { get; private set; } = default!;

        // Конструктор для создания нового сотрудника
        public Librarian(string name)
            : this(Guid.NewGuid(), name) { }

        // Защищенный конструктор для восстановления сущности (например, из БД)
        protected Librarian(Guid id, string name)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("ФИО библиотекаря не может быть пустым", nameof(name));

            Name = name;
        }

        // Метод для изменения ФИО (бизнес-логика)
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
