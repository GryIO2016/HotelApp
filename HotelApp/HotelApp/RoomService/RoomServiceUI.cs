using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.RoomService
{
    class RoomServiceUI : IRoomServiceUI
    {
        public bool acceptReservation(Reservation res)
        {
            bool rented = false;
            if (res.Paid == res.TotalPrice)
            {
                foreach (Room room in res.Rooms)
                {
                    room.RoomStatus = EnumHelper.Status.Rent;
                    rented = true;
                }
            }
            return rented;
        }


        public bool editReservation()
        {
            throw new NotImplementedException();
        }

        public bool editRoom()
        {
            throw new NotImplementedException();
        }

        public string notification()
        {
            throw new NotImplementedException();
        }
    }
}
