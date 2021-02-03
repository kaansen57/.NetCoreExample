using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class PersonManager
    {
        //public int ID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string FullName { get; set; }

        public PersonManager()
        {
            //ID = person.ID;   
            //FullName = person.FullName;
        }
        public void Add(IPerson person)
        {       
            Console.WriteLine(person.ID +  "-->"+ person.FullName);
        }

    }
}
