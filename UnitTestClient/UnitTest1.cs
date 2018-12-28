using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client;
using Client.Entities.AlarmEntity;
using RecDll;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UnitTestClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RecQueryStatement qs = new RecQueryStatement();
            qs.RecType = "3";
            //DataSet ds = RecFileClass.SelectRecInfo("1", "30",qs);
           
          

            //DateTime dt = DateTime.Now;
            //RecFileList recFileList = new RecFileList();
            //recFileList.CameraID = "7000";
            //recFileList.RecName = "7000_120180628093008自动.mp4";
            //recFileList.RecRecFile = @"d:\7000_120180628093008自动.mp4";
            //recFileList.RecStartDate = dt.ToString("yyyy-MM-dd");
            //recFileList.RecStartTime = dt.ToString("HH:mm:ss");
            //recFileList.RecType = "3";
            //RecFileClass.AddStartTime(recFileList);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Access.Connection();
            List<string> usernames1= RecPictureClass.GetUserNames();
            //List<string> usernames2 = RecFileClass.GetUserNames();
        }
    }
}
