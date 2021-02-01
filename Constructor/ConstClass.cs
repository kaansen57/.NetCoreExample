using System;
using System.Collections.Generic;
using System.Text;

namespace Constructor
{
    class ConstClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ConstClass()
        {
            Console.WriteLine("Default Constructor");
        }

        //overload
        public ConstClass(int id,string name,string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Console.WriteLine(ID + " : " + Name + " "+Surname);
        }
    }
}
