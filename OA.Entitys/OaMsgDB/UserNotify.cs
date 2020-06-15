using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class UserNotify
    {
        public int Id { get; set; }
        public sbyte? IsRead { get; set; }
        public string UserId { get; set; }
        public int? MsgId { get; set; }
        public int? CreateTime { get; set; }
    }
}
