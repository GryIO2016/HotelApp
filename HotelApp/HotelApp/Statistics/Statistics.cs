using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    public class Statistics 
    {
        DateTime startDate;
        DateTime endDate;
        List<double> statData=new List<double>();
        int categoryID;
        bool notInitialized;
        IStatistics interfejs;
        //ICalendar calendar;

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
            interfejs = new IStatisticsImplementation(/*calendar*/);
        }

        public void updateData()
        {
            statData.Clear();
            if (notInitialized)
            {
                interfejs.getDailyIncome(this);
                notInitialized = false;
            }
            else {
                switch (categoryID)
                {
                    case 0: interfejs.getDailyIncome(this); break;
                    case 1: interfejs.getFreeRooms(this); break;
                    case 2: interfejs.getRoomVacancy(this); break;
                    default: break;
                }
            }
        }
    }
}
