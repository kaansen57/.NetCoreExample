using Business.Abstract;
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

        public void Add(Car car)
        {
            if (car.Id >= 0 && (car.ModelYear.Length <= 4  && car.ModelYear.Length > 0) && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception();
            }
           
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetAll(int password)
        {
            if (password == 1234)
            {
                return _carDal.GetAll();
            }
            else
            {
                throw new Exception();
            }
        }

        public List<Car> GetById(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public void BrandColorGet()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetUnitPriceFilter(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice > min && p.DailyPrice < max);
        }

        public List<CarDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails(); 
        }
    }
}
