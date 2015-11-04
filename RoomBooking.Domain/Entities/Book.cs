using RoomBooking.Domain.Enums;
using RoomBooking.Domain.Validation;
using System;
using System.Collections.Generic;

namespace RoomBooking.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }
        public Room Room { get; private set; }
        public EBookStatus Status { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        //public User User { get; private set; }

        public Book(Room room, DateTime startTime, DateTime endDate)
        {
            AssertionConcern.AssertArgumentNotNull(room, "Informe a sala para a reserva");
            AssertionConcern.AssertArgumentNotNull(startTime, "Informe a data de início");
            AssertionConcern.AssertArgumentNotNull(endDate, "Informe a data de fim da reserva");

            this.Id = Guid.NewGuid();
            this.StartDate = startTime;
            this.EndDate = endDate;
            Status = EBookStatus.InProgress;


        }

        public void Confirm(IList<DateTime> holidays, IList<DateTime> booksForThisPeriod)
        {
            //Verificar se data início está na lista de feriados
            //TODO: verificar se data início está na lsita de reservas
        }

        public void MarkAsInProgress()
        {
            Status = EBookStatus.InUse;
        }

        public void Cancel()
        {
            if ((this.StartDate -DateTime.Now).Hours < 2)
            {
                throw new Exception("Prazo para cancelamento expirado");
            }

            Status = EBookStatus.Canceled;
        }

        public void MarkAsCompleted()
        {
            Status = EBookStatus.Completed;
        }
    }
}
