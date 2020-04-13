using System;
using System.Collections.Generic;
using System.Text;

namespace eWAN.Core.Application.OAuth
{
    public class JWTHeader
    {
        public string algorithm { get; set; }
        public string type { get; set; }
    }
}
