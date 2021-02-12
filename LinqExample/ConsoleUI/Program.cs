using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car { Id = 6, BrandId = 8, ColorId = 3, DailyPrice = "30", Description = "Porsche", ModelYear = "2020" };
            carManager.Add(car1);
            foreach (var item in carManager.GetAll(1234))
            {
                Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            }
            Console.WriteLine("---------------------------------");
            car1 = new Car { Id = 6, BrandId = 8, ColorId = 3, DailyPrice = "30", Description = "Porsche", ModelYear = "2010" };
            carManager.Update(car1);
            foreach (var item in carManager.GetAll(1234))
            {
                Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            }
            Console.WriteLine("---------------------------------");
            carManager.Delete(car1);
            carManager.GetById(3);
            foreach (var item in carManager.GetById(3))
            {
                Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            }
            Console.WriteLine("---------------------------------");
          
            foreach (var item in carManager.GetAll(1234))
            {
                Console.WriteLine(item.Id +" "+item.BrandId +" " +item.Description+" "+item.ModelYear);
            }
            Console.WriteLine("---------------------------------");

            carManager.BrandColorGet();

        }
    }
}
