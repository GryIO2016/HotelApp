using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Timetable
{
    public class Calendar : ICalendarData
    {
        private List<Reservation> reservations = new List<Reservation>();

        public void addReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public void editReservation(Reservation oldReservation, Reservation newReservation)
        {
            if (reservations.Contains(oldReservation))
            {
                reservations[reservations.IndexOf(oldReservation)] = newReservation;
            }
            else
            {
                throw new ReservationNotFoundException();
            }
        }

        public List<Room> getFreeRooms(DateTime startDate, DateTime endTime)
        {
            List<Room> temp = new List<Room>();
            return temp;
        }

        public List<Reservation> getReservations(DateTime startDate, DateTime endDate)
        {
            List<Reservation> temp = new List<Reservation>();
            foreach(Reservation res in reservations)
            {
                if((res.CheckInDate > startDate && res.CheckOutDate > endDate) || (res.CheckInDate < startDate && res.CheckOutDate < endDate))
                {
                    continue;
                }
                else
                {
                    temp.Add(res);
                }
            }
            return temp;
        }

        public List<Reservation> getUserReservations(User user)
        {
            List<Reservation> temp = new List<Reservation>();
            foreach(Reservation res in reservations)
            {
                if (res.User == user)
                {
                    temp.Add(res);
                }
            }
            return temp;
        }
    }
}
