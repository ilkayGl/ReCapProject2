using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log Added to Database");
        }
    }
}
