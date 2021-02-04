using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Polymorphism
{
    class SqlConnection : IConnectionDal
    {
        public void Delete()
        {
            Console.WriteLine("Sql Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Sql Insert");
        }

        public void Update()
        {
            Console.WriteLine("Sql Update");
        }
    }
}
