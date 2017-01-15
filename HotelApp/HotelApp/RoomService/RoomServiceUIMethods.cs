using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.RoomService
{
    class RoomServiceUIMethods : IRoomServiceUI
    {
        public bool acceptReservation(Reservation res)
        {
            throw new NotImplementedException();
        }

        public bool editReservation()
        {
            throw new NotImplementedException();
        }

        public bool editRoom(Room oldRoom, Room newRoom)
        {
            DBManagment dbm = new DBManagment();
            try
            {
                dbm.editRoom(oldRoom, newRoom);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public string notification()
        {
            throw new NotImplementedException();
        }
    }
}
