using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public int? TargetId { get; set; }
        public sbyte? TargetType { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public int? CreateTime { get; set; }
    }
}
