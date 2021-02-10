using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInterfaces
{
    class FileLogService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("File Log");
        }
    }
}
