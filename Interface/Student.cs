using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Student : IPerson
    {
        //public string firstName;
        //public string lastName;

        public int ID { get; set; }
        public string FirstName
        {
            get; set;
            //get { return firstName; }
            //set { firstName = value; }
        }
        public string LastName { get; set; }

        public string FullName { get { return "Sevgili : " + FirstName +" "+ LastName; } set { } }
        public string StudentNumber { get; set; }


    }
}
