using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal()); //parametresi sınıf olanlara  , newleyerek atama yapılır.
             //List<Product> product = productManager.GetAll();
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductId+" "+item.ProductName);
            }

        }
    }
}
