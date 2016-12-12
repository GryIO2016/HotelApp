using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    public class StatisticsUI : IStatisticsUI
    {
        Statistics dane;
        
        public Statistics Dane
        {
            get {  
                return dane;
            }
        }

        public StatisticsUI()
        {
            dane = new Statistics();
        }

        public void plotChart()
        {
            dane.updateData();
            Chart c = new Chart(this);
            c.Show();
        }

        public void setStartDate(DateTime data)
        {
            dane.StartDate = data;
        }

        public void setEndDate(DateTime data)
        {
            dane.EndDate = data;
        }

        public void setCategoryID(int cat)
        {
            dane.CategoryID=cat;
        }
    }
}
