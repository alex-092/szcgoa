using System;
using System.Collections.Generic;

namespace OA.Entitys.OaAuthDB
{
    public partial class AuthUserRoles
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }
}
