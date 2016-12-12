using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool Confirmed { get; set; }
        public bool Paid { get; set; }
        public User User { get; set; }
        public List<Room> Rooms { get; set; }

        public Reservation(int id, User client, DateTime checkInDate, DateTime checkOutDate, List<Room> rooms)
        {
            Id = id;
            User = client;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Rooms = rooms;
        }

        public double CountTotalPrice()
        {
            double TotalPrice = 0;
            TimeSpan TSpan = CheckOutDate - CheckInDate;
            int DateDiff = TSpan.Days;

            foreach (Room room in Rooms)
            {
                TotalPrice += room.Price * DateDiff;
            }

            return TotalPrice;
        }
    }
}
