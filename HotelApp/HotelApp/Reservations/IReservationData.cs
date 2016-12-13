using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Reservations
{
    public interface IReservationData
    {
        List<Reservation> getReservations();
    }
}
