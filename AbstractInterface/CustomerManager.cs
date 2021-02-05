using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{

    //business class
    class CustomerManager
    {
        public void Add(Customer customer)
        {
            Console.WriteLine(customer.Id);
        }
    }
}
