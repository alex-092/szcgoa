using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class MsgReader
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string SenderId { get; set; }
        public int? MsgId { get; set; }
        public int? IsRead { get; set; }
        public int? Status { get; set; }
        public int? CreateTime { get; set; }
    }
}
