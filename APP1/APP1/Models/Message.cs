using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP1.Models
{
    public class Message
    {
        string emailSend;
        string emailReceive;
        string time;
        DateTime date_S;
        DateTime deat;
        DateTime uniqueTime;
        string remark;
        string messages;
        public Message()
        {

        }
        public Message(string emailSend, string emailReceive, string time, DateTime date_S, DateTime deat, DateTime uniqueTime, string remark, string messages)
        {
            EmailSend = emailSend;
            EmailReceive = emailReceive;
            Time = time;
            Date_S = date_S;
            Deat = deat;
            UniqueTime = uniqueTime;
            Remark = remark;
            Messages = messages;
        }

        public string EmailSend { get => emailSend; set => emailSend = value; }
        public string EmailReceive { get => emailReceive; set => emailReceive = value; }
        public string Time { get => time; set => time = value; }
        public DateTime Date_S { get => date_S; set => date_S = value; }
        public DateTime Deat { get => deat; set => deat = value; }
        public DateTime UniqueTime { get => uniqueTime; set => uniqueTime = value; }
        public string Remark { get => remark; set => remark = value; }
        public string Messages { get => messages; set => messages = value; }
    }
}