using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.UnitTest
{
    [TestClass]
    public class StreamServerTest
    {
        [TestMethod]
        public void InsertTes()
        {
            StreamServerListRepository repo = new StreamServerListRepository();
            StreamServerList ServerList = new StreamServerList();
            ServerList.DeviceID = repo.GetGuid();
            ServerList.StreamServerIP = "192.0.0.66";
          
            Guid result = repo.Insert(ServerList);
        }
    }
}
