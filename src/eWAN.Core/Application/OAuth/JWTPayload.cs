using System;
using System.Collections.Generic;
using System.Text;

namespace eWAN.Core.Application.OAuth
{
    public class JWTPayload
    {
        public string name { get; set; }
        public DateTime expire_date { get; set; }
        public string permission_code { get; set; }
    }
}
