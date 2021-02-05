using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Corporate corporate = new Corporate();
            corporate.Id = 1;
            corporate.CustomerNumber = "12345";
            corporate.CompanyName = "Company";
            corporate.TaxNo = "1234556";

            Individual individual = new Individual();
            individual.Id = 2;
            individual.CustomerNumber = "12345667";
            individual.FirstName = "Joe";
            individual.LastName = "Doe";
            individual.TcNo = "999999";


            Customer customer1customer1 = new Corporate();
            Customer customer2 = new Individual();

            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(corporate);
            customerManager.Add(individual);


        }
    }
}
