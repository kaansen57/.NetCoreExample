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
            if (car.Id >= 0)
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
            if(brandId >= 3)
            {
                return _carDal.GetById(brandId);
            }
            else
            {
                throw new Exception();
            }
        }

        public void BrandColorGet()
        {
             _carDal.BrandColorGet();
        }
    }
}
