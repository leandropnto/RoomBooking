using RoomBooking.Domain.Validation;
using System;

namespace RoomBooking.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Title { get; private set; }

        public Room(DateTime startDate, DateTime endDate, string title)
        {
            AssertionConcern.AssertArgumentNotNull(startDate, "Horário de início inválido");
            AssertionConcern.AssertArgumentNotNull(endDate, "Horário de termino inválido");
            AssertionConcern.AssertArgumentNotEmpty(title, "Título inválido");
            AssertionConcern.AssertArgumentLength(title, 3, 40, "Nome da sala deve conter entre 3 e 40 caracteres");

            this.Id = Guid.NewGuid();
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Title = title;
        }
    }
}
