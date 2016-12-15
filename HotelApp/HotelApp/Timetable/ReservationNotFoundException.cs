using System;

namespace HotelApp.Timetable
{
    public class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException()
        {
        }

        public ReservationNotFoundException(string message) : base(message)
        {
        }

        public ReservationNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
