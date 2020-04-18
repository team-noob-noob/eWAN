using System;
using System.Collections.Generic;
using System.Text;

namespace eWAN.Core.Infrastructure.OAuth
{
    public class AccessToken
    {
        public string token_type { get; set; } 
        public string access_token { get; set; }
    }
}
