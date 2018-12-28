using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegratedManagement
{
    public class IMCommunicate : CommunicateBase
    {
        public IMCommunicate(string remoteIP, int remotePort, string localIP)
            : base(remoteIP, remotePort, localIP)
        {

        }
    }
}
