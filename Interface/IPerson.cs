using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    interface IPerson
    {
         int ID { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         string FullName { get; set; }

    }
}
