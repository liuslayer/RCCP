﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OMServer
{
    /// <summary>
    ///  封装ManualResetEvent
    /// </summary>
    public class MutipleThreadResetEvent : IDisposable
    {
        private readonly ManualResetEvent mre;
        private readonly int total;
        private long current;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="total">需要等待执行的线程总数</param>
        public MutipleThreadResetEvent(int total)
        {
            this.total = total;
            current = total;
            mre = new ManualResetEvent(false);
        }

        /// <summary>
        /// 唤醒一个等待的线程
        /// </summary>
        public void SetOne()
        {
            // Interlocked 原子操作类 ,此处将计数器减1
            if (Interlocked.Decrement(ref current) == 0)
            {
                //当所以等待线程执行完毕时，唤醒等待的线程
                mre.Set();
            }
        }

        /// <summary>
        /// 等待所以线程执行完毕
        /// </summary>
        public void WaitAll()
        {
            mre.WaitOne();
        }

        /// <summary>
        /// 在指定时间等待所以线程执行完毕
        /// </summary>
        public void WaitAll(int millisecondsTimeout)
        {
            mre.WaitOne(millisecondsTimeout);
        }

        /// <summary>
        /// 释放对象占用的空间
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)mre).Dispose();
        }
    }
}