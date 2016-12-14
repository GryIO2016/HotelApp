using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public bool Smoking { get; set; }
        public bool Pets { get; set; }
        public EnumHelper.BedType BedType { get; set; }
        public EnumHelper.Status RoomStatus { get; set; }


        public Room(int id, int number, double price, bool smoking, bool pets, EnumHelper.BedType bedType, EnumHelper.Status status)
        {
            Id = id;
            Number = number;
            Price = price;
            Smoking = smoking;
            Pets = pets;
            BedType = bedType;
            RoomStatus = status;
        }

        public Room()
        {
        }

        public void toString()
        {
            Console.WriteLine("Room " + Id + ", " + Number + ", " + Price + ", smoking: " + Smoking + ", pets: " + Pets + ", " + BedType + ", " + RoomStatus);
        }
    }
}
