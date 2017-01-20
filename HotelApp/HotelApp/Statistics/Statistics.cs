using HotelApp.Database;
using HotelApp.Timetable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    public class Statistics : IStatistics
    {
        DateTime startDate;
        DateTime endDate;
        List<double> statData=new List<double>();
        int categoryID;
        bool notInitialized;
        ICalendar calendar;

        public DateTime StartDate {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public List<double> StatData {
            get
            {
                return statData;
            }
        }

        public int CategoryID {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
            }
        }

        public Statistics ()
        {
            notInitialized = true;
            calendar = new Calendar();
        }

        public void updateData()
        {
            statData.Clear();
            if (notInitialized)
            {
                getDailyIncome();
                notInitialized = false;
            }
            else {
                switch (categoryID)
                {
                    case 0: getDailyIncome(); break;
                    case 1: getFreeRooms(); break;
                    case 2: getRoomVacancy(); break;
                    default: break;
                }
            }
        }

        public void getDailyIncome()
        {
            DateTime data = this.StartDate;
            while (data < this.EndDate)
            {
                double przychod = 0.0;
                foreach (Reservation r in calendar.getReservations(this.StartDate, this.EndDate))
                {
                    if (r.CheckInDate.Date == data) przychod += r.Paid;
                }
                this.StatData.Add(przychod);
                data = data.AddDays(1.0);
            }
        }

        public void getFreeRooms()
        {
            DateTime data = this.StartDate;
            while (data < this.EndDate)
            {
                double wolne = 0.0;

                wolne += calendar.getFreeRooms(data, data).Count;
                this.StatData.Add(wolne);
                data = data.AddDays(1.0);
            }
        }

        public void getRoomVacancy()
        {
            DateTime data = this.StartDate;
            while (data < this.EndDate)
            {
                double zajetosc = 0.0;
                zajetosc += calendar.getReservations(data, data).Count;
                this.StatData.Add(zajetosc);
                data = data.AddDays(1.0);
            }
        }
    }
}
