using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Customer : IPerson
    {
        //public string firstName; //field

        public int ID { get; set; }
        public string FirstName
        {
            get; set;
        }

        public string LastName { get; set; }

        public string FullName { get { return "Sayın : " +FirstName + " "+ LastName; } set { }  }
        public string CustomerNumber { get; set; }
    }
}
