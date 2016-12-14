using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelApp.Statistics
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        StatisticsUI statystyki;
        public StatisticsWindow()
        {
            InitializeComponent();
            statystyki = new StatisticsUI();
        }
        
        private void buttonPlot_Click(object sender, RoutedEventArgs e)
        {
            statystyki.setCategoryID(categoryComboBox.SelectedIndex);
            statystyki.setStartDate(startDateBox.SelectedDate.Value);
            statystyki.setEndDate(endDateBox.SelectedDate.Value);
            statystyki.plotChart();
        }
        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
