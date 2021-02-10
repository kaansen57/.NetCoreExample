using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //global değişkenler _ ile başlar best practice
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
                new Product{CategoryId = 1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{CategoryId = 2,ProductId=2,ProductName="Kamera",UnitPrice=500,UnitsInStock=2},
                new Product{CategoryId = 3,ProductId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=3},
                new Product{CategoryId = 4,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{CategoryId = 5,ProductId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product deleteData = null;
            //foreach (var item in _products)
            //{
            //    if (item.ProductId == product.ProductId)
            //    {
            //        deleteData = item;
            //    }
            //}
            deleteData = _products.SingleOrDefault(x =>x.ProductId ==product.ProductId);

            _products.Remove(deleteData);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();

        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void Update(Product product)
        {
            Product updateData = null;
            updateData = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            updateData.ProductId = product.ProductId;
            updateData.ProductName = product.ProductName;

            
        }
    }
}
