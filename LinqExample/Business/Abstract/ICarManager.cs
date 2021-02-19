using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        List<Car> GetAll(int password);

        List<Car> GetById(int brandId);

        List<Car> GetUnitPriceFilter(int min, int max);

        IResult BrandColorGet();

        List<CarDTO> GetCarDetails();
    }
}
