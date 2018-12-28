using Client.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurntableControlInterface
{
    public partial class UpsDataFrom : Form
    {
        public UpsDataFrom()
        {
            InitializeComponent();
            listView1.Columns.Add("名称",200);
            listView1.Columns.Add("输入电压",100);
            listView1.Columns.Add("上一次转电池放电时电压",180);
            listView1.Columns.Add("输出电压",100);
            listView1.Columns.Add("输出负载百分比",100);
            listView1.Columns.Add("输入频率",100);
            listView1.Columns.Add("电池单元电压",100);
            listView1.Columns.Add("温度",100);
            //listView1.Columns.Add("时间");
            this.listView1.View = System.Windows.Forms.View.Details;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpsDataGet();
        }

        void UpsDataGet()
        {
            List<DynamicDataOfUps3onedata> tmpUpsData = InterfaceControl.GetUpsData();
            if (tmpUpsData != null)
            {
                this.listView1.Items.Clear();
                ListViewItem lvi;
                for (int i = 0; i < tmpUpsData.Count; i++)
                {
                    lvi = new ListViewItem();
                    lvi.Text = tmpUpsData[i].UpsName;
                    lvi.SubItems.Add(tmpUpsData[i].INVOLTAGE.ToString());//(i_INVOLTAGE.ToString());     //电池组电压 
                    lvi.SubItems.Add(tmpUpsData[i].LVOLTAGE.ToString());//(i_LVOLTAGE.ToString());     //电池组电流
                    lvi.SubItems.Add(tmpUpsData[i].OUTVOLTAGE.ToString());//(i_OUTVOLTAGE.ToString());        //电池组温度
                    lvi.SubItems.Add(tmpUpsData[i].LOAD.ToString());//(i_LOAD.ToString());        //电池组湿度
                    lvi.SubItems.Add(tmpUpsData[i].FREQ.ToString());//(i_FREQ.ToString());       //发电量
                    lvi.SubItems.Add(tmpUpsData[i].CELLVOLTAGE.ToString());//(i_CELLVOLTAGE.ToString());        //储存电流
                    lvi.SubItems.Add(tmpUpsData[i].TEMP.ToString());//(i_TEMP.ToString());         //实时负载电量
                    //lvi.SubItems.Add(tmpUpsData[i].time);//(m_TIME);         //时间
                    this.listView1.Items.Add(lvi);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
