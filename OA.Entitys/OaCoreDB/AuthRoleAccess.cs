using System;
using System.Collections.Generic;

namespace OA.Entitys.OaCoreDB
{
    public partial class AuthRoleAccess
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string MenuIdString { get; set; }
    }
}
