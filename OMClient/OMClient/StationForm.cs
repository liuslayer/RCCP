using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMClient
{
    public partial class StationForm : Form
    {
        public Guid ID;
        public MapForm mapForm;
        public StationForm(MapForm mapForm,int stationStatus)
        {
            InitializeComponent();
            this.mapForm = mapForm;
            this.labelX1_StationStatus.Text = Enum.Parse(typeof(StationStatus), stationStatus.ToString()).ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            mapForm.markerIDList.Remove(ID);
            this.Close();
        }
    }
}
