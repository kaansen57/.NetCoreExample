using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Polymorphism
{
    class MongoConnection : IConnectionDal
    {
        public void Delete()
        {
            Console.WriteLine("Mongo Delete");
        }

        public void Insert()
        {
            Console.WriteLine("Mongo Insert");
        }

        public void Update()
        {
            Console.WriteLine("Mongo Update");
        }
    }
}
