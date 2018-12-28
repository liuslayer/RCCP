using DatabaseConfiguration.CommandFunction;
using DatabaseConfiguration.DeviceEntitiy;
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

namespace DatabaseConfiguration.add_edit_dialogs
{
    public partial class Add_Modify_DeviceType : Form
    {
        public DialogResult result = DialogResult.Cancel;
        private string InitPath = "c:\\";//保存上次打开文件的路径 
        DeviceTypeList tmp1;
        public Add_Modify_DeviceType(DeviceTypeList tmpData)
        {
            InitializeComponent();
            if(tmpData == null)
            {
                tmp1 = tmpData;
            }
            else
            {
                tmp1 = tmpData;
                DeviceTypeData(tmp1);
            }
        }

        private void DeviceTypeData(DeviceTypeList _tmpDeviceData)
        {
            txt_TypeName.Text = _tmpDeviceData.TypeName;
            text_TypeID.Text = _tmpDeviceData.TypeID.ToString();
            if(_tmpDeviceData.Image1 !=null)
            { text_Image1.Text = "已有正常图片"; } else { }
            if (_tmpDeviceData.Image2 != null)
            { text_Image2.Text = "已有异常图片"; } else { }
            if (_tmpDeviceData.Image3 != null)
            { text_Image3.Text = "已有报警图片"; } else { }
            txt_Description.Text = _tmpDeviceData.Description;
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            int typeID = 0;
            List<DeviceTypeList> tmpDeviceTypeList = new List<DeviceTypeList>();
            DeviceTypeList _DeviceTypeList = new DeviceTypeList();
            DeviceType_Command tmpDeviceType_Command = new DeviceType_Command();

            if (txt_TypeName.Text.Trim() == "")
            { MessageBox.Show("请填写设备名字"); return; }

            if (text_TypeID.Text.Trim() == "")
            { MessageBox.Show("请填写设备类型编号"); return; }
            else
            {
                if (!Int32.TryParse(text_TypeID.Text.Trim(), out typeID))
                {
                    MessageBox.Show("设备类型编号为数值类型");
                    return;
                }
            }

            _DeviceTypeList.TypeName = txt_TypeName.Text.Trim();
            _DeviceTypeList.TypeID = Convert.ToInt32(text_TypeID.Text.Trim());
            if (tmp1 != null)
            {
                _DeviceTypeList.ID = tmp1.ID;
            }
            
            if (text_Image1.Text != "已有正常图片")
            {
                if (text_Image1.Text != null && text_Image1.Text != "")
                {
                    if (FileSize(text_Image1.Text)<55000 && FileSize(text_Image1.Text)>0)
                    {
                        _DeviceTypeList.Image1 = GetPictureData(text_Image1.Text);
                    }
                    else
                    { MessageBox.Show("正常图片大于50KB"); }
                    
                }
                else { _DeviceTypeList.Image1 = null; }
            }
            else { _DeviceTypeList.Image1 = tmp1.Image1; }
            
            if(text_Image2.Text != "已有异常图片")
            {
                if (text_Image2.Text != null && text_Image2.Text != "")
                {
                    if(FileSize(text_Image2.Text) < 55000 && FileSize(text_Image2.Text) > 0)
                    {
                        _DeviceTypeList.Image2 = GetPictureData(text_Image2.Text);
                    }
                    else
                    { MessageBox.Show("异常图片大于50KB"); }

                }
                else { _DeviceTypeList.Image2 = null; }
            }
            else { _DeviceTypeList.Image2 = tmp1.Image2; }

            if (text_Image3.Text != "已有报警图片")
            {
                if (text_Image3.Text != null && text_Image3.Text != "")
                {
                    if (FileSize(text_Image3.Text) < 55000 && FileSize(text_Image3.Text) > 0)
                    {
                        _DeviceTypeList.Image3 = GetPictureData(text_Image3.Text);
                    }
                    else
                    { MessageBox.Show("报警图片大于50KB"); }
                    
                }
                else { _DeviceTypeList.Image3 = null; }
            }
            else { _DeviceTypeList.Image3 = tmp1.Image3; }

            _DeviceTypeList.Description = txt_Description.Text.Trim();
            tmpDeviceTypeList.Add(_DeviceTypeList);
            if(tmp1==null)
            {
                tmpDeviceType_Command._AddData(tmpDeviceTypeList);
                result = MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                tmpDeviceType_Command._ReviseData(tmpDeviceTypeList);
                result = MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK);
            }
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Image1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.InitialDirectory = InitPath;
            //fileDialog.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            //fileDialog.RestoreDirectory = true;
            //fileDialog.FilterIndex = 1;
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = fileDialog.FileName;
            //    InitPath = System.IO.Path.GetDirectoryName(filePath);
            //    text_Image1.Text = fileDialog.FileName;
            //}
            text_Image1.Text = GetPicturePath();
        }

        private void button_Image2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.InitialDirectory = InitPath;
            //fileDialog.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            //fileDialog.RestoreDirectory = true;
            //fileDialog.FilterIndex = 1;
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = fileDialog.FileName;
            //    InitPath = System.IO.Path.GetDirectoryName(filePath);
            //    text_Image2.Text = fileDialog.FileName;
            //}
            text_Image2.Text = GetPicturePath();
        }

        private void button_Image3_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.InitialDirectory = InitPath;
            //fileDialog.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            //fileDialog.RestoreDirectory = true;
            //fileDialog.FilterIndex = 1;
            //if (fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = fileDialog.FileName;
            //    InitPath = System.IO.Path.GetDirectoryName(filePath);
            //    text_Image3.Text = fileDialog.FileName;
            //}

            text_Image3.Text = GetPicturePath();
        }

        public string GetPicturePath()
        {
            string strPicturePath = "";

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = InitPath;
            fileDialog.Filter = "图像文件(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png";
            fileDialog.RestoreDirectory = true;
            fileDialog.FilterIndex = 1;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                InitPath = System.IO.Path.GetDirectoryName(filePath);
                strPicturePath = fileDialog.FileName;
            }

            return strPicturePath;
        }

        public byte[] GetPictureData(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }

        public static long FileSize(string filePath)
        {
            long temp = 0;

            //判断当前路径所指向的是否为文件
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string s1 in str1)
                {
                    temp += FileSize(s1);
                }
            }
            else
            {

                //定义一个FileInfo对象,使之与filePath所指向的文件向关联, 
                //以获取其大小
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }

    }
}
