using System;
using System.Collections.Generic;

namespace OA.Entitys.OaAuthDB
{
    public partial class AuthRoles
    {
        public int Id { get; set; }
        public string Rolename { get; set; }
        public string Roledescript { get; set; }
        public sbyte? Level { get; set; }
    }
}
