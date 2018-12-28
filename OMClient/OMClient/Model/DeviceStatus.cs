using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class DeviceStatus
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public bool IsExcept { get; set; }
        public string ExceptDescpiton { get; set; }
        public string Time { get; set; }

        private string map = "转到地图";
        public string Map
        {
            set
            {
                map = value;
            }
            get
            {
                return map;
            }
        }
    }
}
