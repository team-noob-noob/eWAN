﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eWAN.Core.Application.OAuth
{
    public class AccessToken
    {
        public string token_type { get; set; } 
        public string access_token { get; set; }
    }
}
