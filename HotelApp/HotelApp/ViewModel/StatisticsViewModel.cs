using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Statistics;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight;

namespace HotelApp.ViewModel
{
    public class StatisticsViewModel: ViewModelBase
    {
        private DateTime startDate = DateTime.Now;
        private DateTime endDate = DateTime.Now;
        private int categoryID;
        private IStatisticsUI statystyki;
        public ICommand StatisticsShow  { get; private set; }
        public StatisticsViewModel()
        {
            statystyki = new HotelApp.Statistics.StatisticsUI();
            StatisticsShow = new RelayCommand(ShowStatisticsCommand);
        }
        private void ShowStatisticsCommand()
        {
            statystyki.setCategoryID(categoryID);
            statystyki.setStartDate(startDate);
            statystyki.setEndDate(endDate);
            statystyki.plotChart();
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                RaisePropertyChanged();
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                RaisePropertyChanged();
            }
        }
        public int CategoryId
        {
            get { return categoryID; }
            set
            {
                categoryID = value;
                RaisePropertyChanged();
            }
        }
    }
}
