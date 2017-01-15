using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Timetable
{
    public interface ICalendar
    {
        void addReservation(Reservation reservation);
        void editReservation(Reservation oldReservation, Reservation newReservation);
        List<Room> getFreeRooms(DateTime startDate, DateTime endTime);
        List<Reservation> getReservations(DateTime startDate, DateTime endDate);
        List<Reservation> getAllReservations();
        List<Reservation> getUserReservations(User user);
    }
}
