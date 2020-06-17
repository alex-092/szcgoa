using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class MsgContent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public int? Type { get; set; }
        public int? Subtype { get; set; }
        public int? TargetId { get; set; }
        public string CreateBy { get; set; }
        public int? CreateTime { get; set; }
        public int? IsDelete { get; set; }
        public int? DeleteTime { get; set; }
        public string DeleteBy { get; set; }
    }
}
