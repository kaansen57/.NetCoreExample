using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Polymorphism
{
    class MysqlConnection : IConnectionDal
    {
        public void Delete()
        {
            Console.WriteLine("Mysql Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Mysql Insert");
        }

        public void Update()
        {
            Console.WriteLine("Mysql Update");
        }
    }
}
