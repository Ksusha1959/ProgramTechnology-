using System;
using My_library.Domain.Base;

namespace My_library.Domain
{
    public class Transaction : Entity<Guid>
    {
       
        public Guid BookId { get; private set; }
        public Guid ReaderId { get; private set;
        public Guid LibrarianId { get; private set;

        
        public DateTime IssueDate { get; private set; } 
        public DateTime DueDate { get; private set; }      

        
        public string AvailabilityCheck => "Проверка наличия (True/False)";

       
        public Transaction(
            Guid bookId, 
            Guid readerId, 
            Guid librarianId, 
            DateTime issueDate, 
            DateTime dueDate)
            : this(Guid.NewGuid(), book            bookId, 
            readerId, 
            librarianId, 
            issueDate, 
            dueDate) { }

       
        protected Transaction(
            Guid id,
            Guid bookId,
            Guid readerId,
            Guid librarianId,
            DateTime issueDate,
            DateTime dueDate)
            : base(id)
        {
            
            BookId = bookId;
            ReaderId = readerId;
            LibrarianId = librarianId;

          
            if (issueDate > dueDate)
                throw new ArgumentException("Дата выдачи не может быть позже срока сдачи.");

            IssueDate = issueDate;
            DueDate = dueDate;
        }

       
        public bool ExtendDueDate(DateTime newDueDate)
        {
            if (newDueDate <= IssueDate)
                throw new ArgumentException("Новый срок сдачи должен быть позже даты выдачи.");

            if (DueDate == newDueDate)
                return false;

            DueDate = newDueDate;
            return true;
        }
    }
}
