using System;
using System.Collections.Generic;

namespace OA.Entitys.OaAuthDB
{
    public partial class AuthRoleClaims
    {
        public int Id { get; set; }
        public int Roleid { get; set; }
        public string RoleClaimType { get; set; }
        public string RoleClaimValue { get; set; }
    }
}
