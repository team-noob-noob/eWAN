using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWAN.WebAPIs.RequestBodyModels
{
    public class LogIn
    {
        public string name { get; set; }
        public string access_permission { get; set; }
    }
}
