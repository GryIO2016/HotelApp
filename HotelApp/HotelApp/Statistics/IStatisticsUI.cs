using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Statistics
{
    public interface IStatisticsUI
    {
        void plotChart();
        void setStartDate(DateTime data);
        void setEndDate(DateTime data);
        void setCategoryID(int cat);
    }
}
