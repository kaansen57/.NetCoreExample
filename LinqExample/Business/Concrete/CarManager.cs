using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarManager
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
           
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Ürün Eklendi!");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult("Ürün Eklendi!");
        }

        public IDataResult<List<Car>> GetAll(int password)
        {
            if (password == 1234)
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductList);
            }
            else
            {
               return new ErrorDataResult<List<Car>>(Messages.ProductListError);
            }
        }

        public IDataResult<List<Car>> GetById(int carId)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == carId),Messages.ProductList);
        }

        public IDataResult<List<Car>> GetUnitPriceFilter(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice > min && p.DailyPrice < max));
        }

        public IDataResult<List<CarDTO>> GetCarDetails()
        {
            var cardto = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDTO>>(cardto); 
        }

      
    }
}
