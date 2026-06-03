using System;
using My_library.Domain.Base;

namespace My_library.Domain
{
    public class Book : Entity<Guid>
    {
        
        public string Title { get; private set; } = default!;

        
        public string Status { get; private set; } = default!;

        
        public Book(string title, string status)
            : this(Guid.NewGuid(), title, status) { }

       
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

       
        public bool UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Новое название не может быть пустым", nameof(newTitle));

            if (Title == newTitle)
                return false;

            Title = newTitle;
            return true;
        }

        
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
