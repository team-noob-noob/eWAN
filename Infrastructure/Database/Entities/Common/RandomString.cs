using System;
using System.Linq;

namespace eWAN.Infrastructure.Database.Entities
{
    internal static class RandomString
    {
       public static string NewString(this Random random, int length = 10, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
       {
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
       }
    }
}
