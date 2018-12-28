using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.AdvTree;
using GMap.NET.WindowsForms.Markers;

namespace OMClient
{
    public partial class MapForm : Form
    {
        private List<DeviceStatus> deviceStatusExceptionList = new List<DeviceStatus>();
        private GMapOverlay baseOverlay = new GMapOverlay("baseOverlay"); //放置基础图层

        private GMapOverlay markerOverlay = new GMapOverlay("markerOverlay"); //放置标记图层
        private GMapOverlay polylineOverlay = new GMapOverlay("polylineOverlay"); //放置折线图层
        private GMapOverlay polyline_Temporarily = new GMapOverlay("polyline_Temporarily");//放置临时线路图层
        private GMapRoute drawingPolyline = null; //正在画的polygon
        private List<PointLatLng> drawingPolylinePoints = new List<PointLatLng>(); //折线的点集
        public List<Guid> markerIDList = new List<Guid>();
        private bool isMeasureDistance = false;//是否开始测距
        private bool isClear = false;//是否进行清理
        private bool isTag = false;//是否进行标记

        int PStationLevel = 11;//地图跳转默认图层等级
        int StationLevel = 13;
        int MapSkipLevel = 15;

        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            expandablePanel_DeviceStatusException.Expanded = false;
            expandablePanel_Tool.Expanded = false;
            expandablePanel_Tool.Width = 100;
            comboBoxEx_Map.SelectedIndex = 0;

            AccessIni accessIni = new AccessIni();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
            int.TryParse(accessIni.ReadIni("Settings", "PStationLevel", "11", filePath), out PStationLevel);
            int.TryParse(accessIni.ReadIni("Settings", "StationLevel", "13", filePath), out StationLevel);
            int.TryParse(accessIni.ReadIni("Settings", "MapSkipLevel", "15", filePath), out MapSkipLevel);
            try
            {
                System.Net.IPHostEntry IPHostEntry = System.Net.Dns.GetHostEntry("ditu.google.cn");
                labelX_MapStatus.Text = "在线模式";
            }
            catch
            {
                mapControl.Manager.Mode = AccessMode.CacheOnly;
                labelX_MapStatus.Text = "离线模式";
            }
            mapControl.CacheLocation = Environment.CurrentDirectory + "\\GMapCache\\"; //缓存位置
            mapControl.MapProvider = GMapProviders.GoogleChinaMap; //google china 地图
            mapControl.MinZoom = 2;  //最小比例
            mapControl.MaxZoom = 24; //最大比例
            mapControl.Zoom = 11;     //当前比例
            mapControl.ShowCenter = false; //不显示中心十字点
            mapControl.DragButton = System.Windows.Forms.MouseButtons.Left; //左键拖拽地图
            mapControl.Position = new PointLatLng(30.6599, 104.0657); //地图中心位置：成都

            mapControl.Overlays.Add(baseOverlay);
            mapControl.Overlays.Add(markerOverlay);
            mapControl.Overlays.Add(polylineOverlay);
            mapControl.Overlays.Add(polyline_Temporarily);

            mapControl.MouseMove += new MouseEventHandler(mapControl_OnMouseMove);
            mapControl.MouseClick += new MouseEventHandler(mapControl_MouseClick);
            mapControl.MouseDoubleClick += new MouseEventHandler(mapControl_MouseDoubleClick);

            mapControl.OnMarkerEnter += new MarkerEnter(mapControl_OnMarkerEnter);
            mapControl.OnMarkerLeave += new MarkerLeave(mapControl_OnMarkerLeave);
            mapControl.OnMarkerClick += new MarkerClick(mapControl_OnMarkerClick);
            mapControl.OnRouteEnter += new RouteEnter(mapControl_OnRouteEnter);
            mapControl.OnRouteLeave += new RouteLeave(mapControl_OnRouteLeave);
            mapControl.OnRouteClick += new RouteClick(mapControl_OnRouteClick);
        }

        private void mapControl_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            if (item.Overlay.Id == "polylineOverlay")
            {
                if (isClear)
                {
                    item.Overlay.Routes.Remove(item);
                    isClear = false;
                }
            }
        }

        private void mapControl_OnRouteLeave(GMapRoute item)
        {
            //isRouteSelect = false;
        }

        private void mapControl_OnRouteEnter(GMapRoute item)
        {
            //isRouteSelect = true;
        }

        private void mapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.Overlay.Id == "baseOverlay")
            {
                if (item is GMapMarkerImage)
                {
                    GMapMarkerImage marker = item as GMapMarkerImage;
                    if (markerIDList.Contains(marker.ID))
                        return;

                    if (marker.TypeID == (int)DeviceParamType.TurnTableDevice)
                    {
                        markerIDList.Add(marker.ID);
                        List<CameraList> cameraList = OMClientManager.deviceInfo.CameraList.FindAll(_ => _.Turntable_PTZ_DeviceID == marker.ID);
                        TurntableForm tf = new TurntableForm(this, cameraList, OMClientManager.cameraStatusList, OMClientManager.deviceInfo.StreamMediaList);
                        tf.ID = marker.ID;
                        //tf.CloseForm += new
                        // TurntableForm.CloseFormEventHandler(CloseDisplayForm);
                        tf.lbxTitle.Text = marker.ToolTipText;
                        //df.Location = this.PointToClient(MousePosition);//鼠标相对于窗体的坐标
                        tf.Location = GetStartLocation(MousePosition, tf.Size);
                        tf.TopMost = true;
                        tf.Show();
                    }
                    else if (marker.TypeID == (int)DeviceParamType.UPSDevice)
                    {
                        markerIDList.Add(marker.ID);
                        UPSStatusList UPSStatus = OMClientManager.UPSStatusList.Find(_ => _.DeviceID == marker.ID);
                        UPSForm UPSForm = new UPSForm(this, UPSStatus);
                        UPSForm.ID = marker.ID;
                        UPSForm.lbxTitle.Text = marker.ToolTipText;
                        UPSForm.Location = GetStartLocation(MousePosition, UPSForm.Size);
                        UPSForm.TopMost = true;
                        UPSForm.Show();
                    }
                    else if (marker.TypeID == (int)DeviceParamType.SolarEnergyDevice)
                    {
                        markerIDList.Add(marker.ID);
                        SolarEnergyStatusList SolarEnergyStatus = OMClientManager.solarEnergyStatusList.Find(_ => _.DeviceID == marker.ID);
                        SolarEnergyForm solarEnergyForm = new SolarEnergyForm(this, SolarEnergyStatus);
                        solarEnergyForm.ID = marker.ID;
                        solarEnergyForm.lbxTitle.Text = marker.ToolTipText;
                        solarEnergyForm.Location = GetStartLocation(MousePosition, solarEnergyForm.Size);
                        solarEnergyForm.TopMost = true;
                        solarEnergyForm.Show();
                    }
                    else if (marker.TypeID == (int)DeviceParamType.Station)
                    {
                        markerIDList.Add(marker.ID);
                        int stationStatus = 0;
                        if (OMClientManager.stationStatusDic.ContainsKey(marker.ID))
                        {
                            stationStatus = OMClientManager.stationStatusDic[marker.ID];
                        }
                        StationForm stationForm = new StationForm(this, stationStatus);
                        stationForm.ID = marker.ID;
                        stationForm.lbxTitle.Text = marker.ToolTipText;
                        stationForm.Location = GetStartLocation(MousePosition, stationForm.Size);
                        stationForm.TopMost = true;
                        stationForm.Show();
                    }
                }
            }
            else if (item.Overlay.Id == "markerOverlay")
            {
                if (isClear)
                {
                    item.Overlay.Markers.Remove(item);
                    isClear = false;
                }
            }
        }
        /// <summary>
        /// 设置窗口弹出位置，避免在地图上显示不全
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <param name="formSize"></param>
        /// <returns></returns>
        private Point GetStartLocation(Point mousePosition, Size formSize)
        {
            Point mapFormLocation = this.Location;
            Size mapFormSize = this.Size;
            Point p = mousePosition;
            if (mapFormLocation.X + mapFormSize.Width < mousePosition.X + formSize.Width)
            {
                p.X = mousePosition.X - formSize.Width;
            }
            if (mapFormLocation.Y + mapFormSize.Height < mousePosition.Y + formSize.Height)
            {
                p.Y= mousePosition.Y - formSize.Height;
            }
            return p;
        }

        private void mapControl_OnMarkerLeave(GMapMarker item)
        {
            //isMarkerSelect = false;
            if (item is GMapMarkerImage)
            {
                GMapMarkerImage imageMarker = item as GMapMarkerImage;
                imageMarker.SelectedPen.Dispose();
                imageMarker.SelectedPen = null;
            }
        }

        private void mapControl_OnMarkerEnter(GMapMarker item)
        {
            //isMarkerSelect = true;
            if (item is GMapMarkerImage)
            {
                GMapMarkerImage imageMarker = item as GMapMarkerImage;
                imageMarker.SelectedPen = new Pen(Brushes.Red, 2);
            }
        }

        private void mapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (isMeasureDistance && drawingPolyline != null)
                {
                    //mapControl.UpdateRouteLocalPosition(drawingPolyline);
                    if (drawingPolylinePoints.Count >= 2)
                    {
                        GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(drawingPolylinePoints[drawingPolylinePoints.Count - 1], GMarkerGoogleType.blue);
                        gMarkerGoogle.ToolTipText = string.Format("总距离={0}千米", drawingPolyline.Distance.ToString());
                        markerOverlay.Markers.Add(gMarkerGoogle);
                    }
                    drawingPolyline = null;
                    drawingPolylinePoints.Clear();
                    isMeasureDistance = false;
                }
            }
        }

        private void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (isMeasureDistance)//测距
                {
                    drawingPolylinePoints.Add(mapControl.FromLocalToLatLng(e.X, e.Y));
                    if (drawingPolyline == null)
                    {
                        drawingPolyline = new GMapRoute(drawingPolylinePoints, "my polyline");
                        drawingPolyline.Stroke = new Pen(Color.Blue, 3);
                        drawingPolyline.IsHitTestVisible = true;
                        polylineOverlay.Routes.Add(drawingPolyline);
                    }
                    else
                    {
                        drawingPolyline.Points.Clear();
                        drawingPolyline.Points.AddRange(drawingPolylinePoints);
                        if (polylineOverlay.Routes.Count == 0)
                        {
                            polylineOverlay.Routes.Add(drawingPolyline);
                        }
                        else
                        {
                            mapControl.UpdateRouteLocalPosition(drawingPolyline);
                        }
                    }
                    polyline_Temporarily.Routes.Clear();
                }
                else if (isTag)//标记
                {
                    GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(new PointLatLng(double.Parse(labelX_Lat.Text), double.Parse(labelX_Lon.Text)), GMarkerGoogleType.blue);
                    gMarkerGoogle.ToolTipText = string.Format("位置：{0},{1}", labelX_Lon.Text, labelX_Lat.Text);
                    markerOverlay.Markers.Add(gMarkerGoogle);
                    isTag = false;
                }
            }
        }

        private void mapControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng pointLatLng = mapControl.FromLocalToLatLng(e.X, e.Y);
            this.labelX_Lon.Text = pointLatLng.Lng.ToString();
            this.labelX_Lat.Text = pointLatLng.Lat.ToString();

            if (isMeasureDistance && drawingPolylinePoints.Count >= 1)
            {
                PointLatLng latLng = this.mapControl.FromLocalToLatLng(e.X, e.Y);
                List<PointLatLng> listPoint1 = new List<PointLatLng>();
                if (latLng != drawingPolylinePoints[drawingPolylinePoints.Count - 1])
                {
                    listPoint1.Add(drawingPolylinePoints[drawingPolylinePoints.Count - 1]);
                    listPoint1.Add(new PointLatLng(latLng.Lat, latLng.Lng));
                    polyline_Temporarily.Routes.Clear();
                    GMapRoute item = new GMapRoute(listPoint1, "line");
                    item.Stroke.Color = Color.Black;
                    item.Stroke.Width = 1;  //设置画线粗细
                    polyline_Temporarily.Routes.Add(item);
                }
            }
        }

        public void UpdateCameraStatus(List<CameraStatusList> newCameraStatusList)
        {
            if (mapControl.InvokeRequired)
            {
                this.Invoke(new Action<List<CameraStatusList>>(UpdateCameraStatus), newCameraStatusList);
            }
            else
            {
                try
                {
                    List<Guid> offlineCameraIDs = newCameraStatusList.FindAll(cs => cs.IsOnline == false).Select(_ => _.DeviceID).ToList();
                    List<CameraList> offLineCameras = OMClientManager.deviceInfo.CameraList.FindAll(_ =>
                    {
                        return offlineCameraIDs.Contains(_.DeviceID);
                    });
                    List<Guid?> offlineTurntableIDs = offLineCameras.Select(_ => _.Turntable_PTZ_DeviceID).Distinct().ToList();
                    //List<TurnTableList> offlineTurnTableList = OMClientManager.deviceInfo.TurnTableList.FindAll(_ =>
                    //{
                    //    return offlineTurntableIDs.Contains(_.DeviceID);
                    //});

                    List<Guid> normalCameraIDs = newCameraStatusList.FindAll(cs => cs.IsOnline == true && cs.SignalStatus == 1 && cs.HardwareStatus == 1).Select(_ => _.DeviceID).ToList();
                    List<CameraList> normalCameras = OMClientManager.deviceInfo.CameraList.FindAll(_ =>
                    {
                        return normalCameraIDs.Contains(_.DeviceID);
                    });
                    List<Guid?> normalTurntableIDs = normalCameras.Select(_ => _.Turntable_PTZ_DeviceID).Distinct().ToList();

                    List<Guid> alarmCameraIDs = newCameraStatusList.FindAll(cs => cs.IsOnline == true && (cs.SignalStatus == 2 || cs.HardwareStatus == 2)).Select(_ => _.DeviceID).ToList();
                    List<CameraList> alarmCameras = OMClientManager.deviceInfo.CameraList.FindAll(_ =>
                    {
                        return alarmCameraIDs.Contains(_.DeviceID);
                    });
                    List<Guid?> alarmTurntableIDs = alarmCameras.Select(_ => _.Turntable_PTZ_DeviceID).Distinct().ToList();

                    //offlineTurntableIDs = offlineTurntableIDs.Except(alarmTurntableIDs).ToList();
                    //normalTurntableIDs = normalTurntableIDs.Except(alarmTurntableIDs).Except(offlineTurntableIDs).ToList();

                    #region 改变离线设备图标
                    string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                    Bitmap bitmap_Turntable_offline = Bitmap.FromFile(Path.Combine(basePath, "Turntable_offline.png")) as Bitmap;
                    Bitmap bitmap_Turntable_normal = Bitmap.FromFile(Path.Combine(basePath, "Turntable_normal.png")) as Bitmap;
                    Bitmap bitmap_Turntable_alarm = Bitmap.FromFile(Path.Combine(basePath, "Turntable_alarm.png")) as Bitmap;

                    foreach (var item in baseOverlay.Markers)
                    {
                        GMapMarkerImage marker = item as GMapMarkerImage;
                        if (marker.TypeID == (int)DeviceParamType.TurnTableDevice)
                        {
                            if (alarmTurntableIDs.Contains(marker.ID))
                            {
                                marker.Image = bitmap_Turntable_alarm;
                                marker.RoutePen = new Pen(Color.Red, 1);
                                mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                                marker.MarkerStatus = MarkerStatus.Alarm;
                            }
                            else if (offlineTurntableIDs.Contains(marker.ID))
                            {
                                marker.Image = bitmap_Turntable_offline;
                                marker.RoutePen = new Pen(Color.Gray, 1);
                                mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                                marker.MarkerStatus = MarkerStatus.Offline;
                            }
                            else if (normalTurntableIDs.Contains(marker.ID))
                            {
                                marker.Image = bitmap_Turntable_normal;
                                marker.RoutePen = new Pen(Color.Blue, 1);
                                mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                                marker.MarkerStatus = MarkerStatus.Normal;
                            }
                        }
                    }
                    mapControl.Refresh();
                    #endregion

                    UpdateCameraExceptionList(OMClientManager.cameraStatusList);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("更新状态信息出错");
                }
            }
        }

        public void UpdateUPSStatus(List<UPSStatusList> newUPSStatusList)
        {
            if (mapControl.InvokeRequired)
            {
                this.Invoke(new Action<List<UPSStatusList>>(UpdateUPSStatus), newUPSStatusList);
            }
            else
            {
                List<Guid> normalList = newUPSStatusList.FindAll(_ => _.Alarm == "00000000").Select(_ => _.DeviceID).ToList();
                List<Guid> alarmList = newUPSStatusList.FindAll(_ => _.Alarm != "00000000").Select(_ => _.DeviceID).ToList();

                #region 改变离线设备图标
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                Bitmap bitmap_UPS_offline = Bitmap.FromFile(Path.Combine(basePath, "UPS_offline.png")) as Bitmap;
                Bitmap bitmap_UPS_normal = Bitmap.FromFile(Path.Combine(basePath, "UPS_normal.png")) as Bitmap;
                Bitmap bitmap_UPS_alarm = Bitmap.FromFile(Path.Combine(basePath, "UPS_alarm.png")) as Bitmap;

                foreach (var item in baseOverlay.Markers)
                {
                    GMapMarkerImage marker = item as GMapMarkerImage;
                    if (marker.TypeID == (int)DeviceParamType.UPSDevice)
                    {
                        if (normalList.Contains(marker.ID))
                        {
                            marker.Image = bitmap_UPS_normal;
                            marker.RoutePen = new Pen(Color.Blue, 1);
                            mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                            marker.MarkerStatus = MarkerStatus.Normal;
                        }
                        else if (alarmList.Contains(marker.ID))
                        {
                            marker.Image = bitmap_UPS_alarm;
                            marker.RoutePen = new Pen(Color.Red, 1);
                            mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                            marker.MarkerStatus = MarkerStatus.Alarm;
                        }
                    }
                }
                mapControl.Refresh();
                #endregion

                UpdateUPSExceptionList(OMClientManager.UPSStatusList);
            }
        }

        public void UpdateSolarEnergyStatus(List<SolarEnergyStatusList> newSolarEnergyStatusList)
        {
            if (mapControl.InvokeRequired)
            {
                this.Invoke(new Action<List<SolarEnergyStatusList>>(UpdateSolarEnergyStatus), newSolarEnergyStatusList);
            }
            else
            {
                List<Guid> normalList = newSolarEnergyStatusList.FindAll(_=>_.Alarm==0).Select(_ => _.DeviceID).ToList();
                List<Guid> alarmList = newSolarEnergyStatusList.FindAll(_ => _.Alarm != 0).Select(_ => _.DeviceID).ToList();

                #region 改变离线设备图标
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                Bitmap bitmap_SolarEnergy_offline = Bitmap.FromFile(Path.Combine(basePath, "SolarEnergy_offline.png")) as Bitmap;
                Bitmap bitmap_SolarEnergy_normal = Bitmap.FromFile(Path.Combine(basePath, "SolarEnergy_normal.png")) as Bitmap;
                Bitmap bitmap_SolarEnergy_alarm = Bitmap.FromFile(Path.Combine(basePath, "SolarEnergy_alarm.png")) as Bitmap;

                foreach (var item in baseOverlay.Markers)
                {
                    GMapMarkerImage marker = item as GMapMarkerImage;
                    if (marker.TypeID == (int)DeviceParamType.SolarEnergyDevice)
                    {
                        if (normalList.Contains(marker.ID))
                        {
                            marker.Image = bitmap_SolarEnergy_normal;
                            marker.RoutePen = new Pen(Color.Blue, 1);
                            mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                            marker.MarkerStatus = MarkerStatus.Normal;
                        }
                        else if(alarmList.Contains(marker.ID))
                        {
                            marker.Image = bitmap_SolarEnergy_alarm;
                            marker.RoutePen = new Pen(Color.Red, 1);
                            mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                            marker.MarkerStatus = MarkerStatus.Alarm;
                        }
                    }
                }
                mapControl.Refresh();
                #endregion

                UpdateSolarEnergyExceptionList(OMClientManager.solarEnergyStatusList);
            }
        }

        public void UpdateStationStatus(Dictionary<Guid, int> newStationStatusDic)
        {
            if (mapControl.InvokeRequired)
            {
                this.Invoke(new Action<Dictionary<Guid, int>>(UpdateStationStatus), newStationStatusDic);
            }
            else
            {
                #region 改变离线设备图标
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                Bitmap bitmap_Station_offline = Bitmap.FromFile(Path.Combine(basePath, "Station_offline.png")) as Bitmap;
                Bitmap bitmap_Station_normal = Bitmap.FromFile(Path.Combine(basePath, "Station_normal.png")) as Bitmap;
                foreach (var item in baseOverlay.Markers)
                {
                    GMapMarkerImage marker = item as GMapMarkerImage;
                    if (marker.TypeID == (int)DeviceParamType.Station)
                    {
                        if (newStationStatusDic.Keys.Contains(marker.ID))
                        {
                            if (newStationStatusDic[marker.ID] == 1 || newStationStatusDic[marker.ID] == 3)//状态为开机或工作，图标点亮
                            {
                                marker.Image = bitmap_Station_normal;
                                marker.RoutePen = new Pen(Color.Blue, 1);
                                mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                                marker.MarkerStatus = MarkerStatus.Normal;

                            }
                            else//其余状态图标置灰
                            {
                                marker.Image = bitmap_Station_offline;
                                marker.RoutePen = new Pen(Color.Gray, 1);
                                mapControl.UpdateRouteLocalPosition(marker.StationRoute);
                                marker.MarkerStatus = MarkerStatus.Offline;
                            }
                        }
                    }
                }
                mapControl.Refresh();
                #endregion
            }
        }

        private delegate void UpdateDeviceInfoDel(DeviceInfo deviceInfo);
        public void UpdateDeviceInfo(DeviceInfo deviceInfo)
        {
            if (mapControl.InvokeRequired)
            {
                UpdateDeviceInfoDel updateDeviceInfoDel = new
                 UpdateDeviceInfoDel(UpdateDeviceInfo);
                this.Invoke(updateDeviceInfoDel, deviceInfo);
            }
            else
            {
                baseOverlay.Markers.Clear();
                baseOverlay.Routes.Clear();
                advTree_Station.ClearAndDisposeAllNodes();
                //RefreshMapControl();
                if (deviceInfo == null)
                    return;
                UpdateStationTree(deviceInfo.StationList);

                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image");
                Bitmap bitmap = Bitmap.FromFile(Path.Combine(basePath, "Turntable_offline.png")) as Bitmap;
                foreach (var item in deviceInfo.TurnTableList)
                {
                    if (item.Lat == null && item.Lon == null)
                        continue;
                    PointLatLng point = new PointLatLng(item.Lat.Value, item.Lon.Value);
                    GMapMarkerImage marker = new GMapMarkerImage(point, bitmap);
                    baseOverlay.Markers.Add(marker);
                    StationList station = deviceInfo.StationList.Find(_ => _.StationID == item.StationID);
                    if (station != null)
                    {
                        marker.CenterPoint = (station.Lat != null && station.Lon != null) ? new PointLatLng(station.Lat.Value, station.Lon.Value) : new PointLatLng();
                        marker.Overlay.Routes.Add(marker.StationRoute);
                    }
                    marker.ID = item.DeviceID;
                    marker.TypeID = item.TypeID;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = item.Name;
                }
                bitmap = Bitmap.FromFile(Path.Combine(basePath, "Station_offline.png")) as Bitmap;
                foreach (var item in deviceInfo.StationList)
                {
                    if (item.Lat == null && item.Lon == null)
                        continue;
                    PointLatLng point = new PointLatLng(item.Lat.Value, item.Lon.Value);
                    GMapMarkerImage marker = new GMapMarkerImage(point, bitmap);
                    baseOverlay.Markers.Add(marker);
                    StationList station = deviceInfo.StationList.Find(_ => _.StationID == item.PStationID);
                    if (station != null)
                    {
                        marker.CenterPoint = (station.Lat != null && station.Lon != null) ? new PointLatLng(station.Lat.Value, station.Lon.Value) : new PointLatLng();
                        marker.Overlay.Routes.Add(marker.StationRoute);
                    }
                    marker.ID = item.StationID;
                    marker.TypeID = item.TypeID;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = item.Name;
                }
                bitmap = Bitmap.FromFile(Path.Combine(basePath, "UPS_offline.png")) as Bitmap;
                foreach (var item in deviceInfo.UPSList)
                {
                    if (item.Lat == null && item.Lon == null)
                        continue;
                    PointLatLng point = new PointLatLng(item.Lat.Value, item.Lon.Value);
                    GMapMarkerImage marker = new GMapMarkerImage(point, bitmap);
                    baseOverlay.Markers.Add(marker);
                    StationList station = deviceInfo.StationList.Find(_ => _.StationID == item.StationID);
                    if (station != null)
                    {
                        marker.CenterPoint = (station.Lat != null && station.Lon != null) ? new PointLatLng(station.Lat.Value, station.Lon.Value) : new PointLatLng();
                        marker.Overlay.Routes.Add(marker.StationRoute);
                    }
                    marker.ID = item.DeviceID;
                    marker.TypeID = item.TypeID;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = item.Name;
                }
                bitmap = Bitmap.FromFile(Path.Combine(basePath, "SolarEnergy_offline.png")) as Bitmap;
                foreach (var item in deviceInfo.SolarEnergyList)
                {
                    if (item.Lat == null && item.Lon == null)
                        continue;
                    PointLatLng point = new PointLatLng(item.Lat.Value, item.Lon.Value);
                    GMapMarkerImage marker = new GMapMarkerImage(point, bitmap);
                    baseOverlay.Markers.Add(marker);
                    StationList station = deviceInfo.StationList.Find(_ => _.StationID == item.StationID);
                    if (station != null)
                    {
                        marker.CenterPoint = (station.Lat != null && station.Lon != null) ? new PointLatLng(station.Lat.Value, station.Lon.Value) : new PointLatLng();
                        marker.Overlay.Routes.Add(marker.StationRoute);
                    }
                    marker.ID = item.DeviceID;
                    marker.TypeID = item.TypeID;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = item.Name;
                }
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
                foreach (var child in childStations.OrderBy(_=>_.Name))
                {
                    Node childNode = new Node();
                    childNode.Tag = child;
                    childNode.Text = child.Name;
                    rootNode.Nodes.Add(childNode);
                }
                advTree_Station.Nodes.Add(rootNode);
            }

            advTree_Station.EndUpdate();
        }

        public delegate void refreshDel();
        private void RefreshMapControl()
        {
            if (mapControl.InvokeRequired)
            {
                refreshDel refreshDel = RefreshMapControl;
                this.Invoke(refreshDel);
            }
            else
            {
                mapControl.Refresh();
            }
        }

        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            expandableSplitter1.Expanded = false;
        }

        private void advTree_Station_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node node = e.Node;
            StationList station = node.Tag as StationList;
            if (station == null)
                return;
            if (!station.Lat.HasValue || !station.Lon.HasValue)
                return;
            mapControl.Position = new PointLatLng(station.Lat.Value, station.Lon.Value);
            if (station.PStationID == null)
            {
                mapControl.Zoom = PStationLevel;
            }
            else
            {
                mapControl.Zoom = StationLevel;
            }
        }

        private object UpdateCameraExceptionLockObj = new object();
        /// <summary>
        /// 更新界面摄像机异常列表
        /// </summary>
        /// <param name="cameraStatusList"></param>
        private void UpdateCameraExceptionList(List<CameraStatusList> cameraStatusList)
        {
            lock (UpdateCameraExceptionLockObj)
            {
                var cameraExceptionList = cameraStatusList.FindAll(_ => _.SignalStatus == 2 || _.HardwareStatus == 2).Select(s =>
                     {
                         return new
                         {
                             DeviceID = s.DeviceID.ToString(),
                             Name = s.Name,
                             AlarmException = OMCommon.CameraExceptionConvert(s.SignalStatus,s.HardwareStatus),
                             Time = s.Time,
                             Map = "转到地图"
                         };
                     }).ToList();
                dataGridViewX_CameraExceptionList.DataSource = cameraExceptionList;
            }
        }

        private void dataGridViewX_CameraExceptionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataGridViewColumn column = dataGridViewX_CameraExceptionList.Columns[e.ColumnIndex];
            if (column is DataGridViewButtonColumn)
            {
                string deviceID = dataGridViewX_CameraExceptionList.Rows[e.RowIndex].Cells[0].Value.ToString();
                CameraList cameraList = OMClientManager.deviceInfo.CameraList.Find(_ => _.DeviceID == Guid.Parse(deviceID));
                TurnTableList turnTableList = OMClientManager.deviceInfo.TurnTableList.Find(_ => _.DeviceID == cameraList.Turntable_PTZ_DeviceID);
                if (turnTableList == null)
                    return;
                if (!turnTableList.Lat.HasValue || !turnTableList.Lon.HasValue)
                    return;
                mapControl.Position = new PointLatLng(turnTableList.Lat.Value, turnTableList.Lon.Value);
                mapControl.Zoom = MapSkipLevel;
            }
        }

        private object UpdateUPSExceptionLockObj = new object();
        /// <summary>
        /// 更新界面UPS异常列表
        /// </summary>
        /// <param name="UPSStatusList"></param>
        private void UpdateUPSExceptionList(List<UPSStatusList> UPSStatusList)
        {
            lock (UpdateUPSExceptionLockObj)
            {
                var UPSExceptionList = UPSStatusList.FindAll(_ => _.Alarm != "00000000").Select(u =>
                     {
                         return new
                         {
                             DeviceID = u.DeviceID.ToString(),
                             Name = u.Name,
                             AlarmException = OMCommon.UPSAlarmConvert(u.Alarm),
                             Time = u.Time,
                             Map = "转到地图"
                         };
                     }).ToList();
                dataGridViewX_UPSExceptionList.DataSource = UPSExceptionList;
            }
        }

        private void dataGridViewX_UPSExceptionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataGridViewColumn column = dataGridViewX_UPSExceptionList.Columns[e.ColumnIndex];
            if (column is DataGridViewButtonColumn)
            {
                string deviceID = dataGridViewX_UPSExceptionList.Rows[e.RowIndex].Cells[0].Value.ToString();
                UPSList ups = OMClientManager.deviceInfo.UPSList.Find(_ => _.DeviceID == Guid.Parse(deviceID));
                if (!ups.Lat.HasValue || !ups.Lon.HasValue)
                    return;
                mapControl.Position = new PointLatLng(ups.Lat.Value, ups.Lon.Value);
                mapControl.Zoom = MapSkipLevel;
            }
        }

        private object UpdateSolarEnergyExceptionLockObj = new object();
        /// <summary>
        /// 更新界面太阳能异常列表
        /// </summary>
        /// <param name="solarEnergyStatusList"></param>
        private void UpdateSolarEnergyExceptionList(List<SolarEnergyStatusList> solarEnergyStatusList)
        {
            lock (UpdateSolarEnergyExceptionLockObj)
            {
                var SolarEnergyExceptionList = solarEnergyStatusList.FindAll(_ => _.Alarm != 0).Select(s =>
                {
                    return new
                    {
                        DeviceID = s.DeviceID.ToString(),
                        Name = s.Name,
                        AlarmException = Enum.Parse(typeof(SolarEnergyAlarmType), s.Alarm.ToString()).ToString(),
                        Time = s.Time,
                        Map = "转到地图"
                    };
                }).ToList();
                dataGridViewX_SolarEnergyExceptionList.DataSource = SolarEnergyExceptionList;
            }
        }

        private void dataGridViewX_SolarEnergyExceptionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            DataGridViewColumn column = dataGridViewX_SolarEnergyExceptionList.Columns[e.ColumnIndex];
            if (column is DataGridViewButtonColumn)
            {
                string deviceID = dataGridViewX_SolarEnergyExceptionList.Rows[e.RowIndex].Cells[0].Value.ToString();
                SolarEnergyList solarEnergy = OMClientManager.deviceInfo.SolarEnergyList.Find(_ => _.DeviceID == Guid.Parse(deviceID));
                if (!solarEnergy.Lat.HasValue || !solarEnergy.Lon.HasValue)
                    return;
                mapControl.Position = new PointLatLng(solarEnergy.Lat.Value, solarEnergy.Lon.Value);
                mapControl.Zoom = MapSkipLevel;
            }
        }

        private void buttonX_distance_Click(object sender, EventArgs e)
        {
            isMeasureDistance = true;
        }

        private void buttonX_Tag_Click(object sender, EventArgs e)
        {
            isTag = true;
        }

        private void buttonX_Clear_Click(object sender, EventArgs e)
        {
            isClear = true;
        }

        private void comboBoxEx_Map_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBoxEx_Map.SelectedIndex == 0)
            {
                mapControl.MapProvider = GMapProviders.GoogleChinaMap;
            }
            else if (comboBoxEx_Map.SelectedIndex == 1)
            {
                mapControl.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
            }
        }

        private void checkBoxX_ExceptionHint_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX_ExceptionHint.Checked)
            {
                timer_Alarm.Start();
            }
            else
            {
                timer_Alarm.Stop();
                foreach (GMapMarker m in baseOverlay.Markers)
                {
                    if (m is GMapMarkerImage)
                    {
                        GMapMarkerImage marker = m as GMapMarkerImage;
                        if (marker.AlarmPen != null)
                        {
                            marker.AlarmPen.Dispose();
                            marker.AlarmPen = null;
                        }
                    }
                }
                mapControl.Refresh();
            }
        }

        private void timer_Alarm_Tick(object sender, EventArgs e)
        {
            foreach (GMapMarker m in baseOverlay.Markers)
            {
                if (m is GMapMarkerImage)
                {
                    GMapMarkerImage marker = m as GMapMarkerImage;
                    if (marker.MarkerStatus == MarkerStatus.Alarm)
                    {
                        if (marker.AlarmPen == null)
                        {
                            marker.AlarmPen = new Pen(Brushes.Red, 2);
                        }
                        else
                        {
                            marker.AlarmPen.Dispose();
                            marker.AlarmPen = null;
                        }
                    }
                }
            }
            mapControl.Refresh();
        }
    }
}
