using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp.Statistics
{
    public partial class Chart : Form
    {
        Statistics s;
        public Chart(StatisticsUI stats)
        {
            s = stats.Dane;
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            string str;
            switch (s.CategoryID)
            {
                case 0: str = "Dzienny przychód"; break;
                case 1: str = "Wolne pokoje"; break;
                case 2: str = "Zajętość pokoju"; break;
                default: str = ""; break;
            }
            Wykres.Series.Add(str);
            DateTime data = s.StartDate;
            foreach (double a in s.StatData) {
                Wykres.Series[str].Points.AddXY(data,a);
                data = data.AddDays(1.0);
            }
        }
    }
}
