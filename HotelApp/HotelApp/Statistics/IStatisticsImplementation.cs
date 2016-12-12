using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    class IStatisticsImplementation : IStatistics 
    {
        //ICalendar calendar;

        public IStatisticsImplementation(/*ICalendar cal*/)
        {
            //calendar = cal;
        }

        public void getDailyIncome(Statistics stat)
        {
            DateTime data = stat.StartDate;
            while (data<stat.EndDate)
            {
                double przychod = 0.0;
                /*foreach (Reservation r in calendar.getReservations(stat.StartDate, stat.EndDate))
                {
                    if (r.CheckinDate.Date == data) przychod += r.Paid;
                }*/
                stat.StatData.Add(przychod);
                data = data.AddDays(1.0);
            }
        }

        public void getFreeRooms(Statistics stat)
        {
            DateTime data = stat.StartDate;
            while (data < stat.EndDate)
            {
                double wolne = 0.0;
                /*foreach (Reservation r in calendar.getReservations(stat.StartDate, stat.EndDate))
                {
                    if (r.CheckinDate.Date == data) przychod += r.Paid;
                }*/
                stat.StatData.Add(wolne);
                data = data.AddDays(1.0);
            }
        }

        public void getRoomVacancy(Statistics stat)
        {
            DateTime data = stat.StartDate;
            while (data < stat.EndDate)
            {
                double zajetosc = 0.0;
                /*foreach (Reservation r in calendar.getReservations(stat.StartDate, stat.EndDate))
                {
                    if (r.CheckinDate.Date == data) przychod += r.Paid;
                }*/
                stat.StatData.Add(zajetosc);
                data = data.AddDays(1.0);
            }
        }
    }
}
