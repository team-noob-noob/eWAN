using System;

namespace eWAN.Core.Infrastructure.Configuration
{
    public class DbConfig
    {
        public static Version MySqlVersion = new Version(5, 7, 32);
        public static string DbConnectionString = "server=localhost;database=ewan;uid=root;pwd=root;";
    }
}
