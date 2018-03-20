using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMServer.Model
{
    [Serializable]
    public class UpsInfos
    {
        public List<UpsInfo> upsList;
    }

    [Serializable]
    public class UpsInfo
    {
        public string ID;
        public string DEPTID;
        public string NAME;
        public string BRAND;
        public string LON;
        public string LAT;
    }
}
