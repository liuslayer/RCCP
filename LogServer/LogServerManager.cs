using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServer
{
    public static class LogServerManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ErrType">错误类型</param>
        /// <param name="ex">异常错误,如果此项为NULL，则需写后三项</param>
        /// <param name="errClass">错误类型</param>
        /// <param name="errMethod">错误方法</param>
        /// <param name="errContent">错误内容</param>
        public static void AddErrLog(ErrLogType ErrType, Exception ex, string errClass = null, string errMethod = null, string errContent = null)
        {
            try
            {
                ErrLogRepository repo = new ErrLogRepository();
                ErrLog errLog = new ErrLog();
                errLog.ErrTime = DateTime.Now;
                errLog.ErrType = (int)ErrType;
                errLog.ErrClass = ex == null ? errClass : ex.TargetSite.ReflectedType.ToString();
                errLog.ErrMethod = ex == null ? errMethod : ex.TargetSite.Name;
                errLog.ErrContent = ex == null ? errContent : ex.ToString();
                repo.Insert(errLog);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationType">操作类型</param>
        /// <param name="OperationContent">操作内容</param>
        /// <param name="Operator">操作者（后台系统可以不写）</param>
        public static void AddRunLog(OperationType operationType, string OperationContent, string Operator = null)
        {
            try
            {
                RunLogRepository repo = new RunLogRepository();
                RunLog runLog = new RunLog();
                runLog.OperationType = (int)operationType;
                runLog.OperationTime = DateTime.Now;
                runLog.Operator = Operator;
                runLog.OperationContent = OperationContent;
                repo.Insert(runLog);
            }
            catch
            {

            }
        }
    }

    public enum OperationType
    {
        /// <summary>
        /// 后台系统
        /// </summary>
        System = 1,
        /// <summary>
        /// 客户端
        /// </summary>
        Client = 2
    }

    public enum ErrLogType
    {
        /// <summary>
        /// 内部异常
        /// </summary>
        InnerErr = 1,
        /// <summary>
        /// 网络异常
        /// </summary>
        NetErr = 2,
        /// <summary>
        /// 报警异常
        /// </summary>
        AlarmErr = 3,
        /// <summary>
        /// 数据库异常
        /// </summary>
        DBErr=4,
        /// <summary>
        /// 接口错误
        /// </summary>
        InterfaceErr
    }

    public enum LogServerCommand
    {
        GetAlarmLog = 1,
        GetRunLog,
        GetErrLog,
        GetAlarmLogResult,
        GetRunLogResult,
        GetErrLogResult
    }
}
