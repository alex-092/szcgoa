using System;
using System.Collections.Generic;

namespace OA.Blazor.Entity.OaCoreDB
{
    public partial class SysMenu
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public sbyte? MenuLevel { get; set; }
        public sbyte? Type { get; set; }
        public int? Order { get; set; }
    }
}
