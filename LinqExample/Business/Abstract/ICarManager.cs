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
        IDataResult<List<Car>> GetAll(int password);
        IDataResult<List<Car>> GetById(int brandId);
        IDataResult<List<Car>> GetUnitPriceFilter(int min, int max);
        IDataResult<List<CarDTO>> GetCarDetails();
        IResult AddTransactionalTest(Car car);
    }
}
