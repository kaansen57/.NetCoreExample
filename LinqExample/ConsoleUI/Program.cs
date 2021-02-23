﻿using Business.Concrete;
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
            //carManagerTest(carManager);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManagerTest(colorManager);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManagerTest(brandManager);

            //carDtoTest(carManager);
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
