using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.RoomService
{
    public class RoomService
    {
        public List<Room> roomsToCleanList (List<Room> roomsList)
        {
            List<Room> roomsToClean = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.RoomStatus == EnumHelper.Status.ToClean)
                {
                    roomsToClean.Add(room);
                }
            }

            return roomsToClean;
        }

        public bool checkRoomAvailability(Room room)
        {
            if (room.RoomStatus == EnumHelper.Status.Free)
                return true;
            else
                return false;
        }

        public List<Room> freeRoomsList (List<Room> roomsList)
        {
            List<Room> freeRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.RoomStatus == EnumHelper.Status.Free)
                {
                    freeRooms.Add(room);
                }

            }
            return freeRooms;
       }
    }
}
