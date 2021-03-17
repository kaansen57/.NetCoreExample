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
            CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));
            //carManagerTest(carManager);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManagerTest(colorManager);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManagerTest(brandManager);

            //carDtoTest(carManager);

            UserManager userManager = new UserManager(new EfUserDal());

            //userManagerTest(userManager);

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //customerManagerTest(customerManager);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManagerTest(rentalManager);

        }

        private static void rentalManagerTest(RentalManager rentalManager)
        {
            Console.WriteLine(rentalManager.Add(new Rental { Id = 4, CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 03, 1), ReturnDate = new DateTime(2021, 03, 03) }).Message);
        }

        private static void customerManagerTest(CustomerManager customerManager)
        {
            Console.WriteLine(customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "Ayancık Rentcar" }).Message);
        }

        private static void userManagerTest(UserManager userManager)
        {
            //var user1 = userManager.Add(new User()
            //{
            //    Id = 2,
            //    FirstName = "Recep",
            //    LastName = "Şen",
            //    Email = "recep@outlook.com",
            //    Password = "123456"
            //}).Message;
            //Console.WriteLine(user1);
            //var user2 = userManager.Delete(new User()
            //{
            //    Id = 2,
            //    FirstName = "Fatma",
            //    LastName = "Şen",
            //    Email = "recep@outlook.com",
            //    Password = "123456"
            //}).Message;
            //Console.WriteLine(user2);

            foreach ( var item in userManager.GetAllList().Data)
            {
                Console.WriteLine(item.Id + item.FirstName + " "+item.LastName);
            }
            Console.WriteLine( userManager.GetCustomer(3).Data.FirstName);
        }

        private static void carDtoTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BrandName + " " + item.ColorName + " " + item.DailyPrice);
                    Console.WriteLine(result.Message);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void brandManagerTest(BrandManager brandManager)
        {
            Brand brand1 = new Brand { BrandId = 8, BrandName = "Lamborgini" };
            Brand brand2 = new Brand { BrandId = 9, BrandName = "Audi" };
            brandManager.Add(brand1);
            brandManager.Add(brand2);
            var getBrand = brandManager.GetBrand(1);
            brandManager.Delete(brand2);
        }

        private static void colorManagerTest(ColorManager colorManager)
        {
            Color color1 = new Color { ColorId = 7, ColorName = "Fuşya" };
            Color color2 = new Color { ColorId = 8, ColorName = "Turkuaz" };
            Color color3 = new Color { ColorId = 8, ColorName = "Mavi" };

            colorManager.Add(color1);
            colorManager.Add(color2);
            foreach (var item in colorManager.GetAllList())
            {
                Console.WriteLine(item.ColorId + " " + item.ColorName);
            }
            colorManager.Update(color3);
        }

        private static void carManagerTest(CarManager carManager)
        {
            Car car1 = new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 540, Description = "Porsche", ModelYear = "2021" };
            carManager.Add(car1);
            car1 = new Car { Id = 7, BrandId = 5, ColorId = 2, DailyPrice = 540, Description = "Porsche", ModelYear = "2015" };
            carManager.Update(car1);
            carManager.Delete(car1);
            var car = carManager.GetById(3).Data;
            var carAllList = carManager.GetAll(1234).Data;
            var carGetPrices = carManager.GetUnitPriceFilter(0, 200).Data;
        }

    }
}
