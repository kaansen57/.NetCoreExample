using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.ID = 1;
            customer.FirstName = "Kaan";
            customer.LastName = "ŞEN";
            customer.CustomerNumber = "1234";

            Student student = new Student();
            student.ID = 2;
            student.FirstName = "Joe";
            student.LastName = "Doe";
            student.StudentNumber = "5678";

            PersonManager personManager = new PersonManager();
            personManager.Add(customer);
            personManager.Add(student);

        }
    }
}
