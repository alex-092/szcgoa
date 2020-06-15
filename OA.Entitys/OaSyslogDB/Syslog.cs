using System;
using System.Collections.Generic;

namespace OA.Entitys.OaSyslogDB
{
    public partial class Syslog
    {
        public int Id { get; set; }
        public int? LogTimestamp { get; set; }
        public string HostName { get; set; }
        public string AppName { get; set; }
        public sbyte? Level { get; set; }
        public string MsgUser { get; set; }
        public string MsgType { get; set; }
        public string MsgContent { get; set; }
    }
}
