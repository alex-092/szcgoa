using System;
using System.Collections.Generic;

namespace OA.Blazor.Entity.OaAuthDB
{
    public partial class AuthUserlogins
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string LoginIp { get; set; }
        public int LoginTimestamp { get; set; }
        public string LoginClient { get; set; }
    }
}
