using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.CCS
{
    public class FileLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Log Added to File");
        }
    }
}
