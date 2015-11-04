using System;

namespace RoomBooking.Domain.Interfaces.Services
{
    public interface IBookService
    {
        //
        void PlaceBook(DateTime startDate, DateTime endDate, Guid user, Guid room);
    }
}
