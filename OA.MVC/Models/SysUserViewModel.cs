using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.MVC.Models
{
    public class SysUserViewModel
    {
    }
    public class SysUserInputModel
    {
        public string Uid { get; set; }
        public string DisplayName { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public sbyte? PhoneConfirmed { get; set; }
        public string Email { get; set; }
        public sbyte UserType { get; set; }
        public sbyte LockType { get; set; }
        public int? LockStamp { get; set; }
        public int? CreateTime { get; set; }
        public sbyte IsDelete { get; set; }
        public int? DeleteTime { get; set; }
    }
}
