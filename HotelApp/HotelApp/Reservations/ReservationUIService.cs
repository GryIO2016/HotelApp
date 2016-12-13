using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;
using HotelApp.Reservations;

namespace HotelApp.Reservations
{
    public class ReservationUIService : IReservationUI
    {
        public bool cancelReservation(int id)
        {
            Reservation found = getReservation(id);

            if (found == null)
            {
                return false;
            }

            found.Canceled = true;
            return true;
        }

        public Reservation createReservation(int id, User client, DateTime checkinDate, DateTime checkoutDate, List<Room> rooms)
        {
            return new Reservation(id, client, checkinDate, checkoutDate, rooms);
        }

        public List<Reservation> getDeletedReservations(User client)
        {
            throw new NotImplementedException();
        }

        public Reservation getReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> getReservations(User client)
        {
            throw new NotImplementedException();
        }

        public List<Room> getRooms(EnumHelper.Status status, List<Room> rooms)
        {
            IEnumerable<Room> result = from Room room in rooms
                                       where room.RoomStatus == status
                                       select room;
            return result.ToList();
        }

        public List<Room> getRooms(EnumHelper.BedType bedType, List<Room> rooms)
        {
            IEnumerable<Room> result = from Room room in rooms
                                       where room.BedType == bedType
                                       select room;
            return result.ToList();
        }

        public List<Room> getRooms(DateTime checkinDate, DateTime checkoutDate, List<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public List<Room> getRooms(double minPrice, double maxPrice, List<Room> rooms)
        {
            IEnumerable<Room> result = from Room room in rooms
                                       where room.Price >= minPrice && room.Price <= maxPrice
                                       select room;
            return result.ToList();
        }

        public List<Room> getRoomsByPets(bool petsAvailable, List<Room> rooms)
        {
            IEnumerable<Room> result = from Room room in rooms
                                       where room.Pets == petsAvailable
                                       select room;
            return result.ToList();
        }

        public List<Room> getRoomsBySmoking(bool smokingAvailable, List<Room> rooms)
        {
            IEnumerable<Room> result = from Room room in rooms
                                       where room.Smoking == smokingAvailable
                                       select room;
            return result.ToList();
        }
    }
}
