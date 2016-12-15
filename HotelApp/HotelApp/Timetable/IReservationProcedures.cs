using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Timetable
{
    public interface IReservationProcedures
    {
        void addReservation(Reservation reservation);
        List<Room> getFreeRooms(DateTime startDate, DateTime endTime);
        void editReservation(Reservation oldReservation, Reservation newReservation);
    }
}
