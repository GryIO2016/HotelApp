using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public static class EnumHelper
    {
        public enum BedType
        {
            Single = 1,
            Twin = 2,
            Double = 3
        };

        public enum Status
        {
            Booking = 1,
            Rent = 2,
            ToClean = 3,
            Free = 4
        };

        public enum Role
        {
            Admin = 1,
            Employee = 2,
            Client = 3
        };
    }
}
