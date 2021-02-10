using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInterfaces
{
    class DatabaseLogService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Database Log");
        }
    }

   
}
