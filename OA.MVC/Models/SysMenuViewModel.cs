using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.MVC.Models
{
    public class SysMenuViewModel
    {
    }
    public class SysMenuInputModel
    {
        public int Pid { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public sbyte MenuLevel { get; set; }
        public sbyte Type { get; set; }
        public int Order { get; set; }
    }

}
