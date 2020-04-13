using System;
using System.Text;

namespace eWAN.Core.Domains.Account
{
    public class RandomGenerator
    {
        public static string RandomIdString(int size)    
        {    
            string newId = DateTime.Now.Year.ToString();
            Random random = new Random();

            for(int i = 0; i < size; i++)
            {
                newId += random.Next(10).ToString();
            }

            return newId;
        } 
    }
}
