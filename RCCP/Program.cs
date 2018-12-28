using HikSdk;
using LogServer;
using RCCP.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请按任何键启动区域指挥中心平台!");
            Console.ReadKey();
            Console.WriteLine();
            var bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize())
            {
                Console.WriteLine("初始化失败!");
                Console.ReadKey();
                return;
            }

            #region 加载基础设备或通信模块
            try
            {
                SerialCOMManager.CreateInstance();
                Console.WriteLine("串口设备初始化完成");
                HikSdkManager hiksdk = HikSdkManager.CreateInstance();
                Console.WriteLine("海康SDK初始化完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
            #endregion

            var result = bootstrap.Start();

            Console.WriteLine("服务正在启动: {0}!", result);

            if (result == StartResult.Failed)
            {
                Console.WriteLine("服务启动失败!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("服务启动成功，请按'q'停止服务!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //停止服务
            // appServer.Stop();
            bootstrap.Stop();
            Console.WriteLine("服务已停止!");
            Console.ReadKey();
        }
    }
}
