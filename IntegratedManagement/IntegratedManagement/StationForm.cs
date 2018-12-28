using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedManagement
{
    public partial class StationForm : Form
    {
        IMCommunicate IMCommunicate;
        List<StationList> stationList = new List<StationList>();
        public StationForm(IMCommunicate IMCommunicate)
        {
            InitializeComponent();
            this.IMCommunicate = IMCommunicate;
        }

        private void StationForm_Load(object sender, EventArgs e)
        {
            RefreshVideo();
        }
        private void RefreshVideo()
        {
            StationListRepository repo = new StationListRepository();
            stationList = repo.GetList();
            dataGridView_StationInfo.DataSource = stationList.Select(_ =>
            {
                return new { _.StationID, _.Name, Lon = _.Lon ?? 0, Lat = _.Lat ?? 0, _.Description, _.Mark };
            }).ToList();
        }

        private void buttonX_PostStaion_Click(object sender, EventArgs e)
        {
            string sendMsg="PostStationInfo "+ JsonConvert.SerializeObject(stationList) + "\r\n";
            IMCommunicate.SendMsgToServer(sendMsg);
        }
    }
}
