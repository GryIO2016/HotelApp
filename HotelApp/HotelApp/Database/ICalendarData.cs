using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public interface ICalendarData
    {
        void addReservation(Reservation reservation);
        void editReservation(Reservation oldReservation, Reservation newReservation);
        List<Room> getFreeRooms(DateTime startDate, DateTime endTime);
        List<Room> getAllRooms();
        List<Reservation> getReservations(DateTime startDate, DateTime endDate);
        List<Reservation> getUserReservations(User user);
        Room getRoom(int id);
        void editRoom(Room oldRoom, Room newRoom);
    }
}
