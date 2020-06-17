using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class MsgSender
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public int? MsgId { get; set; }
        public string ReaderId { get; set; }
        public int? Status { get; set; }
        public int? CreateTime { get; set; }
    }
}
