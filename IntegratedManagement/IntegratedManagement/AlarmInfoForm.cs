using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
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
    public partial class AlarmInfoForm : Form
    {
        IMCommunicate IMCommunicate;
        List<AlarmInfo> alarmInfoList = new List<AlarmInfo>();
        public AlarmInfoForm(IMCommunicate IMCommunicate)
        {
            InitializeComponent();
            this.IMCommunicate = IMCommunicate;
        }

        private void AlarmInfoForm_Load(object sender, EventArgs e)
        {
            RefreshAlarmInfo();
        }

        private void RefreshAlarmInfo()
        {
            AlarmInfoRepository repo = new AlarmInfoRepository();
            alarmInfoList = repo.GetList();
            dataGridView_AlarmInfo.DataSource = alarmInfoList.Select(_ =>
            {
                return new
                {
                    _.ID,
                    _.AlarmID,
                    _.AlarmLocation,
                    _.AlarmTime,
                    AlarmType = Enum.Parse(typeof(AlarmType), _.AlarmType.ToString()).ToString(),
                    TargetAttribute = Enum.Parse(typeof(TargetAttribute), _.TargetAttribute.ToString()).ToString(),
                    _.Description,
                    _.Mark
                };
            }).ToList();
        }

        private void buttonX_Add_Click(object sender, EventArgs e)
        {
            AlarmInfoAddAndEditForm AlarmInfoAddAndEditForm = new AlarmInfoAddAndEditForm(IMCommunicate);
            if (AlarmInfoAddAndEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshAlarmInfo();
            }
        }

        private void buttonX_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_AlarmInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_AlarmInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var AlarmInfo = alarmInfoList.Find(_ => _.ID == ID);
            if (AlarmInfo == null)
            {
                MessageBox.Show("数据错误");
                return;
            }

            try
            {
                AlarmInfoRepository repo = new AlarmInfoRepository();
                repo.Delete(ID);
                RefreshAlarmInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonX_Search_Click(object sender, EventArgs e)
        {
            StringBuilder searchCondition = new StringBuilder(" where 1=1");

            if (!dateTimeInput_TimeStart.IsEmpty)
            {
                searchCondition.Append(" and AlarmTime>@TimeStart");
            }
            if (!dateTimeInput_TimeEnd.IsEmpty)
            {
                searchCondition.Append(" and AlarmTime<@TimeEnd");
            }
            if (!string.IsNullOrWhiteSpace(comboBoxEx_AlarmType.Text))
            {
                searchCondition.Append(" and AlarmType=@AlarmType");
            }
            if (!string.IsNullOrWhiteSpace(comboBoxEx_TargetAttribute.Text))
            {
                searchCondition.Append(" and TargetAttribute=@TargetAttribute");
            }

            AlarmInfoRepository repo = new AlarmInfoRepository();
            alarmInfoList = repo.GetListWithCondition(searchCondition.ToString(), new
            {
                TimeStart = dateTimeInput_TimeStart.Value,
                TimeEnd = dateTimeInput_TimeEnd.Value,
                AlarmType = comboBoxEx_AlarmType.SelectedIndex,
                TargetAttribute = comboBoxEx_TargetAttribute.SelectedIndex
            });
            dataGridView_AlarmInfo.DataSource = alarmInfoList.Select(_ =>
            {
                return new
                {
                    _.ID,
                    _.AlarmID,
                    _.AlarmLocation,
                    _.AlarmTime,
                    AlarmType = Enum.Parse(typeof(AlarmType), _.AlarmType.ToString()).ToString(),
                    TargetAttribute = Enum.Parse(typeof(TargetAttribute), _.TargetAttribute.ToString()).ToString(),
                    _.Description,
                    _.Mark
                };
            }).ToList();
        }

        private void buttonX_Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in panelEx_Search.Controls)
            {
                if (item is DateTimeInput)
                {
                    var dateTimeInput = item as DateTimeInput;
                    dateTimeInput.IsEmpty = true;
                }
                if (item is TextBoxX)
                {
                    var textBoxX = item as TextBoxX;
                    textBoxX.Clear();
                }
                if (item is ComboBoxEx)
                {
                    var comboxEx = item as ComboBoxEx;
                    comboxEx.Text = string.Empty;
                }
            }
        }
    }

    /// <summary>
    /// 报警类别：0其他，1视频，2雷达，3震动光缆，4微波墙
    /// </summary>
    public enum AlarmType
    {
        其他=0,
        视频,
        雷达,
        震动光缆,
        微波墙
    }

    /// <summary>
    /// 目标性质：0其他，1人，2车
    /// </summary>
    public enum TargetAttribute
    {
        其他 = 0,
        人,
        车,
    }
}
