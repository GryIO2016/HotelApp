using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Reservations
{
    public class ReservationStorage
    {
        private static ReservationStorage instance;
        private List<Reservation> reservations;
        private ReservationStorage()
        {
            reservations = new List<Reservation>();
        }
        public void addReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public void clearList()
        {
            reservations.Clear();
        }

        public static ReservationStorage Instance
        {
            get
            {
                if (instance == null) instance = new ReservationStorage();
                return instance;
            }
        }

        public List<Reservation> Reservations
        {
            get { return reservations; }
        }
    }
}
