using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 540, Description = "Porsche", ModelYear = "2021" };
            //carManager.Add(car1);
            //foreach (var item in carManager.GetAll(1234))
            //{
            //    Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            //}
            //Console.WriteLine("---------------------------------");
            //car1 = new Car { Id = 6, BrandId = 4, ColorId = 3, DailyPrice = 30, Description = "Porsche", ModelYear = "2010" };
            //carManager.Update(car1);
            //foreach (var item in carManager.GetAll(1234))
            //{
            //    Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            //}
            //Console.WriteLine("---------------------------------");
            //carManager.Delete(car1);
            //carManager.GetById(3);
            //foreach (var item in carManager.GetById(3))
            //{
            //    Console.WriteLine(item.Id + " " + item.BrandId + " " + item.Description + " " + item.ModelYear);
            //}
            //Console.WriteLine("---------------------------------");

            //foreach (var item in carManager.GetAll(1234))
            //{
            //    Console.WriteLine(item.Id +" "+item.BrandId +" " +item.Description+" "+item.ModelYear);
            //}
            //Console.WriteLine("---------------------------------");

            //foreach (var item in carManager.GetAll(1234))
            //{
            //    Console.WriteLine(item.Id + " " +item.Description);
            //}

            foreach (var item in carManager.GetById(2))
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }
            Console.WriteLine("-------");

            foreach (var item in carManager.GetUnitPriceFilter(0,200))
            {
                Console.WriteLine(item.Id + " " + item.Description);
            }

            carManager.Add(car1);
        }
    }
}
