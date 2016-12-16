using HotelApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Reservations
{
    public interface IReservationUI
    {
        Reservation createReservation(int id, User client, DateTime checkinDate, DateTime checkoutDate, List<Room> rooms);
        List<Room> getRooms(double minPrice, double maxPrice, List<Room> rooms);
        List<Room> getRoomsBySmoking(bool smokingAvailable, List<Room> rooms);
        List<Room> getRoomsByPets(bool petsAvailable, List<Room> rooms);
        List<Room> getRooms(EnumHelper.BedType bedType, List<Room> rooms);
        List<Room> getRooms(DateTime checkinDate, DateTime checkoutDate, List<Room> rooms);
        List<Room> getRooms(EnumHelper.Status status, List<Room> rooms);
        bool cancelReservation(int id, List<Reservation> reservations);
        Reservation getReservation(int id, List<Reservation> reservations);
        List<Reservation> getReservations(User client, List<Reservation> reservations);
        List<Reservation> getDeletedReservations(User client, List<Reservation> reservations);
    }
}
