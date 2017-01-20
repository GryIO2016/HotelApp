using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    interface IStatistics
    {
        void getFreeRooms();
        void getDailyIncome();
        void getRoomVacancy();
    }
}
