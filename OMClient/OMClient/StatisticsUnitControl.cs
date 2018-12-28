using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class StatisticsUnitControl : UserControl
    {
        public StatisticsUnitControl()
        {
            InitializeComponent();
            List<string> xData = new List<string>() { "无数据" };
            List<int> yData = new List<int>() { -1 };
            this.chart1.Series[0].Points.DataBindXY(xData, yData);
            this.chart1.Series[0].Points[0].Color = Color.Gray;
        }
    }
}
