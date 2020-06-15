using System;
using System.Collections.Generic;

namespace OA.Blazor.Entity.OaAuthDB
{
    public partial class AuthUsers
    {
        public string Uid { get; set; }
        public string DisplayName { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public sbyte? PhoneConfirmed { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public sbyte UserType { get; set; }
        public sbyte LockType { get; set; }
        public int? LockStamp { get; set; }
        public int? CreateTime { get; set; }
        public sbyte IsDelete { get; set; }
        public int? DeleteTime { get; set; }
    }
}
