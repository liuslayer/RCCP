
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class GMapMarkerImage : GMapMarker
    {
        private List<PointLatLng> pointList = new List<PointLatLng>();

        public Guid ID { get; set; }
        public int TypeID { get; set; }
        public MarkerStatus MarkerStatus { get; set; }

        private PointLatLng _centerPoint;
        public PointLatLng CenterPoint
        {
            set
            {
                _centerPoint = value;
                if (!_centerPoint.IsEmpty)
                {
                    pointList.Add(_centerPoint);
                    pointList.Add(this.Position);
                    //GMapRoute gmr = new GMapRoute(pointList, "tmp gmr");
                    //gmr.Stroke = RoutePen;
                    //Overlay.Routes.Add(gmr);
                }
            }
        }

        private GMapRoute _stationRoute;
        public GMapRoute StationRoute
        {
            get
            {
                if (pointList.Count == 0)
                {
                    return new GMapRoute("tmp gmr");
                }
                if (_stationRoute == null)
                {
                    _stationRoute = new GMapRoute(pointList, "tmp gmr");
                }
                _stationRoute.Stroke = RoutePen;
                return _stationRoute;
            }
        }


        private Image image;
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                if (image != null)
                {
                    this.Size = new Size(50, 50);
                }
            }
        }

        private Image imageOffline;
        /// <summary>
        /// 离线状态图片
        /// </summary>
        public Image ImageOffline
        {
            get
            {
                return imageOffline;
            }
            set
            {
                imageOffline = value;
                if (imageOffline != null)
                {
                    this.Size = new Size(50, 50);
                }
            }
        }

        private Image imageAlarm;
        /// <summary>
        /// 报警状态图片
        /// </summary>
        public Image ImageAlarm
        {
            get
            {
                return imageAlarm;
            }
            set
            {
                imageAlarm = value;
                if (imageAlarm != null)
                {
                    this.Size = new Size(50, 50);
                }
            }
        }
        /// <summary>
        /// 图标边框
        /// </summary>
        public Pen SelectedPen
        {
            get;
            set;
        }
        /// <summary>
        /// 报警闪烁框
        /// </summary>
        public Pen AlarmPen
        {
            get;
            set;
        }

        private Pen _routePen = new Pen(Color.Gray, 1);
        public Pen RoutePen
        {
            get
            {
                return _routePen;
            }
            set
            {
                _routePen = value;
            }
        }

        public GMapMarkerImage(GMap.NET.PointLatLng p, Image image)
            : base(p)
        {
            Size = new System.Drawing.Size(50, 50);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
            this.image = image;
            SelectedPen = null;
            AlarmPen = null;

            //if (!CenterPoint.IsEmpty)
            //{
            //    List<PointLatLng> pointList = new List<PointLatLng>();
            //    pointList.Add(CenterPoint);
            //    pointList.Add(this.Position);
            //    GMapRoute gmr = new GMapRoute(pointList, "tmp gmr");
            //    gmr.Stroke = RoutePen;
            //    Overlay.Routes.Add(gmr);
            //}
        }

        public override void OnRender(Graphics g)
        {
            if (image == null)
                return;

            Rectangle rect = new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
            g.DrawImage(image, rect);

            if (SelectedPen != null)
            {
                g.DrawRectangle(SelectedPen, rect);
            }

            if (AlarmPen != null)
            {
                g.DrawEllipse(AlarmPen, rect);
            }
        }
    }

    public enum MarkerStatus
    {
        Normal,
        Offline,
        Alarm
    }
}
