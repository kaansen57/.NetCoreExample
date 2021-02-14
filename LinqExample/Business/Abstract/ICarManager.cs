using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager
    {
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

        List<Car> GetAll(int password);

        List<Car> GetById(int brandId);

        List<Car> GetUnitPriceFilter(int min, int max);

       void BrandColorGet();
    }
}
