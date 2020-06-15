using System;
using System.Collections.Generic;

namespace OA.Entitys.OaCoreDB
{
    public partial class SysTasklist
    {
        public int Id { get; set; }
        public int? HandleType { get; set; }
        public string HandleUid { get; set; }
        public string HandleName { get; set; }
        public string TargetUid { get; set; }
        public string TargetName { get; set; }
        public int? TaskType { get; set; }
        public int? Isdone { get; set; }
        public int? CreateTime { get; set; }
    }
}
