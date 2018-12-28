using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedManagement
{
    public partial class VideoRecAddAndEditForm : Form
    {
        string operType = string.Empty;
        VideoRec vr;
        public VideoRecAddAndEditForm(string operType, VideoRec vr)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType.Equals("Edit"))
            {
                labelX_Name.Text = "编辑视频录像";
                this.vr = vr;
                textBoxX_Path.Text = vr.VideoRecPath;
                textBoxX_Name.Text = vr.VideoRecName;
                dateTimeInput_Time.Value = vr.RecTime;
                textBoxX_Location.Text = vr.RecLocation;
                textBoxX_Src.Text = vr.RecSrc;
                textBoxX_EventType.Text = vr.EventType;
                textBoxX_Description.Text = vr.Description;
            }
            else
            {
                labelX_Name.Text = "新增视频录像";
            }
        }

        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            VideoRecRepository repo = new VideoRecRepository();
            try
            {
                if (operType.Equals("Add"))
                {
                    VideoRec newVR = new VideoRec();
                    newVR.VideoRecPath = textBoxX_Path.Text;
                    newVR.VideoRecName = textBoxX_Name.Text;
                    newVR.RecTime = dateTimeInput_Time.Value;
                    newVR.RecLocation = textBoxX_Location.Text;
                    newVR.RecSrc = textBoxX_Src.Text;
                    newVR.EventType = textBoxX_EventType.Text;
                    newVR.Description = textBoxX_Description.Text;
                    repo.Insert(newVR);

                }
                else
                {
                    vr.VideoRecPath = textBoxX_Path.Text;
                    vr.VideoRecName = textBoxX_Name.Text;
                    vr.RecTime = dateTimeInput_Time.Value;
                    vr.RecLocation = textBoxX_Location.Text;
                    vr.RecSrc = textBoxX_Src.Text;
                    vr.EventType = textBoxX_EventType.Text;
                    vr.Description = textBoxX_Description.Text;
                    repo.Update(vr);
                }
                this.DialogResult = DialogResult.OK ;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonX_SelectVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "全部|*.*|MP4|*.MP4|wmv|*.wmv|avi|*.avi|rmvb|*.rmvb";
            ofd.ShowDialog();
            textBoxX_Path.Text = ofd.FileName;
            textBoxX_Name.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
        }
    }
}
