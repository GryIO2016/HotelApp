using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Reservations
{
    public class ReservationDataService : IReservationData
    {
        List<Reservation> IReservationData.getReservations()
        {
            return ReservationStorage.Instance.Reservations;
        }
    }
}
