using System;
using System.Collections.Generic;

namespace OA.Entitys.OaAuthDB
{
    public partial class AuthUserClaims
    {
        public uint Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
