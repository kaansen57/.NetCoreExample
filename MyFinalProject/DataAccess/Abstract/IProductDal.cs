﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetProducts();
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetAllByCategory(int categoryId);

    }
}
