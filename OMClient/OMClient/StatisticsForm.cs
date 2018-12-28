using DevComponents.AdvTree;
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

namespace OMClient
{
    public partial class StatisticsForm : Form
    {
        private StationList currentStation;//当前选中的工作站
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            statisticsUnitControl1.chart1.Titles[0].Text = "摄像机实时在线率";
            statisticsUnitControl2.chart1.Titles[0].Text = "UPS实时在线率";
            statisticsUnitControl3.chart1.Titles[0].Text = "太阳能实时在线率";
        }
        /// <summary>
        /// 摄像机实时在线率：摄像机设备总数备-已收到到摄像机状态数
        /// </summary>
        /// <param name="newCameraStatusList"></param>
        public void UpdateCameraStatus(List<CameraStatusList> newCameraStatusList)
        {
            if (statisticsUnitControl1.InvokeRequired)
            {
                this.Invoke(new Action<List<CameraStatusList>>(UpdateCameraStatus), newCameraStatusList);
            }
            else
            {
                int onlineCount = 0;
                int offlineCount = 0;
                List<string> xData = new List<string>() { "在线", "离线" };
                if (!currentStation.PStationID.HasValue)//中心站，统计所有本级及下级在线率
                {
                    onlineCount = OMClientManager.cameraStatusList.FindAll(cs => cs.IsOnline == true).Count;
                    offlineCount = OMClientManager.deviceInfo.CameraList.Count - onlineCount;
                }
                else// 下级工作站，只统计该下级工作站的在线率
                {
                    List<TurnTableList> turnTableList = OMClientManager.deviceInfo.TurnTableList.FindAll(_ => _.StationID == currentStation.StationID);
                    List<Guid> turnTableIDs = turnTableList.Select(t => t.DeviceID).ToList();
                    List<CameraList> cameraList = OMClientManager.deviceInfo.CameraList.FindAll(_ => turnTableIDs.Contains(_.Turntable_PTZ_DeviceID.HasValue ? _.Turntable_PTZ_DeviceID.Value : Guid.Empty));
                    List<Guid> cameraIDs = cameraList.Select(_ => _.DeviceID).ToList();
                    List<CameraStatusList> tempCameraStatusList = OMClientManager.cameraStatusList.FindAll(_ => cameraIDs.Contains(_.DeviceID));

                    onlineCount = tempCameraStatusList.FindAll(cs => cs.IsOnline == true).Count;
                    offlineCount = cameraList.Count - onlineCount;
                }
                List<int> yData = new List<int>() { onlineCount, offlineCount };
                statisticsUnitControl1.chart1.Series[0].Points.DataBindXY(xData, yData);
            }
        }
        /// <summary>
        /// UPS实时在线率：UPS设备总数-已收到到UPS状态数
        /// </summary>
        /// <param name="newUPSStatusList"></param>
        public void UpdateUPSStatus(List<UPSStatusList> newUPSStatusList)
        {
            if (statisticsUnitControl1.InvokeRequired)
            {
                this.Invoke(new Action<List<UPSStatusList>>(UpdateUPSStatus), newUPSStatusList);
            }
            else
            {
                int onlineCount = 0;
                int offlineCount = 0;
                List<string> xData = new List<string>() { "在线", "离线" };
                if (!currentStation.PStationID.HasValue)//中心站，统计所有本级及下级在线率
                {
                    onlineCount = OMClientManager.UPSStatusList.Count;
                    offlineCount = OMClientManager.deviceInfo.UPSList.Count - onlineCount;
                }
                else// 下级工作站，只统计该下级工作站的在线率
                {
                    List<UPSList> UPSList = OMClientManager.deviceInfo.UPSList.FindAll(_ => _.StationID == currentStation.StationID);
                    List<Guid> UPSIDs = UPSList.Select(_ => _.DeviceID).ToList();
                    List<UPSStatusList> tempUPSStatusList = OMClientManager.UPSStatusList.FindAll(_ => UPSIDs.Contains(_.DeviceID));

                    onlineCount = tempUPSStatusList.Count;
                    offlineCount = UPSList.Count - onlineCount;
                }
                List<int> yData = new List<int>() { onlineCount, offlineCount };
                statisticsUnitControl2.chart1.Series[0].Points.DataBindXY(xData, yData);
            }
        }
        /// <summary>
        /// 太阳能实时在线率：太阳能设备总数-已收到到太阳能状态数
        /// </summary>
        /// <param name="newSolarEnergyStatusList"></param>
        public void UpdateSolarEnergyStatus(List<SolarEnergyStatusList> newSolarEnergyStatusList)
        {
            if (statisticsUnitControl1.InvokeRequired)
            {
                this.Invoke(new Action<List<SolarEnergyStatusList>>(UpdateSolarEnergyStatus), newSolarEnergyStatusList);
            }
            else
            {
                int onlineCount = 0;
                int offlineCount = 0;
                List<string> xData = new List<string>() { "在线", "离线" };
                if (!currentStation.PStationID.HasValue)//中心站，统计所有本级及下级在线率
                {
                    onlineCount = OMClientManager.solarEnergyStatusList.Count;
                    offlineCount = OMClientManager.deviceInfo.SolarEnergyList.Count - onlineCount;
                }
                else// 下级工作站，只统计该下级工作站的在线率
                {
                    List<SolarEnergyList> solarEnergyList = OMClientManager.deviceInfo.SolarEnergyList.FindAll(_ => _.StationID == currentStation.StationID);
                    List<Guid> solarEnergyIDs = solarEnergyList.Select(_ => _.DeviceID).ToList();
                    List<SolarEnergyStatusList> tempSolarEnergyStatusList = OMClientManager.solarEnergyStatusList.FindAll(_ => solarEnergyIDs.Contains(_.DeviceID));

                    onlineCount = tempSolarEnergyStatusList.Count;
                    offlineCount = solarEnergyList.Count - onlineCount;
                }
                List<int> yData = new List<int>() { onlineCount, offlineCount };
                statisticsUnitControl3.chart1.Series[0].Points.DataBindXY(xData, yData);
            }
        }

        private delegate void UpdateDeviceInfoDel(DeviceInfo deviceInfo);
        public void UpdateDeviceInfo(DeviceInfo deviceInfo)
        {
            if (advTree_Station.InvokeRequired)
            {
                UpdateDeviceInfoDel updateDeviceInfoDel = new
                 UpdateDeviceInfoDel(UpdateDeviceInfo);
                this.Invoke(updateDeviceInfoDel, deviceInfo);
            }
            else
            {
                advTree_Station.ClearAndDisposeAllNodes();
                if (deviceInfo == null)
                    return;
                UpdateStationTree(deviceInfo.StationList);
            }
        }

        private void UpdateStationTree(List<StationList> stationList)
        {
            advTree_Station.BeginUpdate();
            Node descriptionNode = new Node();
            descriptionNode.Text = @"<b>站点索引</b>";
            descriptionNode.ExpandVisibility = eNodeExpandVisibility.Hidden;
            descriptionNode.FullRowBackground = true;
            descriptionNode.Selectable = false;
            advTree_Station.Nodes.Add(descriptionNode);

            List<StationList> rootStations = stationList.FindAll(_ => _.PStationID == null);
            foreach (var root in rootStations)
            {
                Node rootNode = new Node();
                rootNode.Tag = root;
                rootNode.Text = root.Name;
                List<StationList> childStations = stationList.FindAll(_ => _.PStationID == root.StationID);
                foreach (var child in childStations.OrderBy(_ => _.Name))
                {
                    Node childNode = new Node();
                    childNode.Tag = child;
                    childNode.Text = child.Name;
                    rootNode.Nodes.Add(childNode);
                }
                advTree_Station.Nodes.Add(rootNode);
            }
            advTree_Station.EndUpdate();
            currentStation = rootStations[0];
        }

        private void advTree_Station_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            StationList station = node.Tag as StationList;
            if (station == null)
                return;
            currentStation = station;
            UpdateCameraStatus(null);
            UpdateUPSStatus(null);
            UpdateSolarEnergyStatus(null);
        }
    }
}
