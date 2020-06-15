using System;
using System.Collections.Generic;

namespace OA.Entitys.OaMsgDB
{
    public partial class ConfigClaim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
