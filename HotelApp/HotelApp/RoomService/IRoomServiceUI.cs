using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.RoomService
{
    interface IRoomServiceUI
    {
        bool acceptReservation();
        bool editReservation();
        bool editRoom();
        String notification();
    }
}
