using HotelApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.RoomService
{
    public interface IRoomServiceUI
    {
        bool acceptReservation(Reservation res);
        bool editReservation();
        bool editRoom();
        String notification();
    }
}
