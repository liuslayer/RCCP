using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RCCP.Repository.Entities
{
    /// <summary>
    /// MailTable:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MailTable
    {
        public MailTable()
        { }
        #region Model
        private Guid _mailid;
        private string _receiverip;
        private string _receiver;
        private string _senderip;
        private string _sender;
        private DateTime _sendtime;
        private string _mailtitle;
        private string _mailcontent;
        private string _mailfilename;
        private string _mailfilestoragename;
        private bool _isread;
        private string _mark;
        /// <summary>
        /// 邮件ID
        /// </summary>
        [Key]
        public Guid MailID
        {
            set { _mailid = value; }
            get { return _mailid; }
        }
        /// <summary>
        /// 收件人IP
        /// </summary>
        public string ReceiverIP
        {
            set { _receiverip = value; }
            get { return _receiverip; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Receiver
        {
            set { _receiver = value; }
            get { return _receiver; }
        }
        /// <summary>
        /// 发件人IP
        /// </summary>
        public string SenderIP
        {
            set { _senderip = value; }
            get { return _senderip; }
        }
        /// <summary>
        /// 发送人
        /// </summary>
        public string Sender
        {
            set { _sender = value; }
            get { return _sender; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string MailTitle
        {
            set { _mailtitle = value; }
            get { return _mailtitle; }
        }
        /// <summary>
        /// 邮件正文
        /// </summary>
        public string MailContent
        {
            set { _mailcontent = value; }
            get { return _mailcontent; }
        }
        /// <summary>
        /// 附件名
        /// </summary>
        public string MailFileName
        {
            set { _mailfilename = value; }
            get { return _mailfilename; }
        }
        /// <summary>
        /// 附件存储名
        /// </summary>
        public string MailFileStorageName
        {
            set { _mailfilestoragename = value; }
            get { return _mailfilestoragename; }
        }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead
        {
            set { _isread = value; }
            get { return _isread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 发送文件监听端口
        /// </summary>
        [Editable(false)]
        public int MailFileListenPort { get; set; }
        /// <summary>
        /// 接收人列表，用于群发
        /// </summary>
        [Editable(false)]
        public Dictionary<string, string> ReceiverDic { get; set; }

        #endregion Model

    }
}

