using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.RoomService
{
    public static class RoomService
    {
        public static Room getRoomByNumber(int number)
        {
            Room room = new Room();
            if (number == room.Number)
            {
                return room;
            }
            return null;
        }
        ////////////////////////////////////////////////////////////////
        public static bool checkRoomAvailability(Room room)
        {
            if (room.RoomStatus == EnumHelper.Status.Free)
                return true;
            else
                return false;
        }
        ////////////////////////////////////////////////////////////////
        public static List<Room> roomsToCleanList(List<Room> roomsList)
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
        ////////////////////////////////////////////////////////////////
        public static List<Room> freeRoomsList (List<Room> roomsList)
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
       //////////////////////////////////////////////////////////////////
       public static void cleanRoom (Room room)
        {
            room.RoomStatus = EnumHelper.Status.Free; //założenie, że pokój jest czyszczony po 
                                                      //rezerwacji (czyli po wyczyszczeniu jest dostępny)
        }
        ////////////////////////////////////////////////////////////////
        public static List<Room> roomsWithSingleBed(List<Room> roomsList)
        {
            List<Room> singleBedRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.BedType == EnumHelper.BedType.Single)
                {
                    singleBedRooms.Add(room);
                }

            }
            return singleBedRooms;
        }
        ///////////////////////////////////////////////////////////////
        public static List<Room> roomsWithTwinBed(List<Room> roomsList)
        {
            List<Room> twinBedRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.BedType == EnumHelper.BedType.Twin)
                {
                    twinBedRooms.Add(room);
                }

            }
            return twinBedRooms;
        }
        ///////////////////////////////////////////////////////////////
        public static List<Room> roomsWithDoubleBed(List<Room> roomsList)
        {
            List<Room> doubleBedRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.BedType == EnumHelper.BedType.Twin)
                {
                    doubleBedRooms.Add(room);
                }

            }
            return doubleBedRooms;
        }
        ////////////////////////////////////////////////////////////////
        public static List<Room> roomsForSmokers(List<Room> roomsList)
        {
            List<Room> smokersRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.Smoking == true)
                {
                    smokersRooms.Add(room);
                }
            }
            return smokersRooms;
        }
        ////////////////////////////////////////////////////////////////
        public static List<Room> roomsAllowingPets(List<Room> roomsList)
        {
            List<Room> petsRooms = new List<Room>();
            foreach (Room room in roomsList)
            {
                if (room.Pets == true)
                {
                    petsRooms.Add(room);
                }
            }
            return petsRooms;
        }
    }
}
