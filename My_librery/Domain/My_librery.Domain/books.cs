using System;
using My_library.Domain.Base;

namespace My_library.Domain
{
    public class Book : Entity<Guid>
    {
        // Свойство Title соответствует полю 'title' (Название книги)
        public string Title { get; private set; } = default!;

        // Свойство Status соответствует полю 'status' (ТЕКУЩЕЕ МЕСТОНАХОЖДЕНИЕ)
        public string Status { get; private set; } = default!;

        // Конструктор для создания новой книги
        public Book(string title, string status)
            : this(Guid.NewGuid(), title, status) { }

        // Защищенный конструктор для ORM (EF Core)
        protected Book(Guid id, string title, string status)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название книги не может быть пустым", nameof(title));

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Статус книги не может быть пустым", nameof(status));

            Title = title;
            Status = status;
        }

        // Метод для обновления названия книги
        public bool UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Новое название не может быть пустым", nameof(newTitle));

            if (Title == newTitle)
                return false;

            Title = newTitle;
            return true;
        }

        // Метод для изменения статуса (например, перемещение из библиотеки к читателю)
        public bool UpdateStatus(string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("Новый статус не может быть пустым", nameof(newStatus));

            if (Status == newStatus)
                return false;

            Status = newStatus;
            return true;
        }
    }
}
