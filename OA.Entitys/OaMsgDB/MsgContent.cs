using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class MsgContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Type { get; set; }
        public int? Action { get; set; }
        public int? TargetType { get; set; }
        public string TargetUserid { get; set; }
        public int? TargetId { get; set; }
        public string SenderUserid { get; set; }
        public int CreateTime { get; set; }
        public int? UpdateTime { get; set; }
        public int? IsDelete { get; set; }
        public int? DeleteTime { get; set; }
    }
}
