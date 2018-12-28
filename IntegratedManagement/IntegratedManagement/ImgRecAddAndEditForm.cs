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
    public partial class ImgRecAddAndEditForm : Form
    {
        string operType = string.Empty;
        ImgRec imgRec;
        public ImgRecAddAndEditForm(string operType, ImgRec imgRec)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType.Equals("Edit"))
            {
                this.imgRec = imgRec;
                labelX_Name.Text = "编辑图片";
                textBoxX_Path.Text = imgRec.ImgRecPath;
                textBoxX_Name.Text = imgRec.ImgRecName;
                dateTimeInput_Time.Value = imgRec.RecTime;
                textBoxX_Location.Text = imgRec.RecLocation;
                textBoxX_Src.Text = imgRec.RecSrc;
                textBoxX_EventType.Text = imgRec.EventType;
                textBoxX_Description.Text = imgRec.Description;
            }
            else
            {
                labelX_Name.Text = "新增图片";
            }
        }

        private void buttonX_SelectImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "全部|*.*|BMP|*.BMP|GIF|*.GIF|JPEG|*.JPEG|JPG|*.JPG|PNG|*.PNG";
            ofd.ShowDialog();
            textBoxX_Path.Text = ofd.FileName;
            textBoxX_Name.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
        }

        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            ImgRecRepository repo = new ImgRecRepository();
            try
            {
                if (operType.Equals("Add"))
                {
                    ImgRec newImgRec = new ImgRec();
                    newImgRec.ImgRecPath = textBoxX_Path.Text;
                    newImgRec.ImgRecName = textBoxX_Name.Text;
                    newImgRec.RecTime = dateTimeInput_Time.Value;
                    newImgRec.RecLocation = textBoxX_Location.Text;
                    newImgRec.RecSrc = textBoxX_Src.Text;
                    newImgRec.EventType = textBoxX_EventType.Text;
                    newImgRec.Description = textBoxX_Description.Text;
                    repo.Insert(newImgRec);

                }
                else
                {
                    imgRec.ImgRecPath = textBoxX_Path.Text;
                    imgRec.ImgRecName = textBoxX_Name.Text;
                    imgRec.RecTime = dateTimeInput_Time.Value;
                    imgRec.RecLocation = textBoxX_Location.Text;
                    imgRec.RecSrc = textBoxX_Src.Text;
                    imgRec.EventType = textBoxX_EventType.Text;
                    imgRec.Description = textBoxX_Description.Text;
                    repo.Update(imgRec);
                }
                this.DialogResult = DialogResult.OK;
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
    }
}
