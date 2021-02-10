using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice="300",Description="Audi",ModelYear = "1998"},
                new Car{Id=2,BrandId=2,ColorId=1,DailyPrice="500",Description="Mercedes",ModelYear = "1998"},
                new Car{Id=3,BrandId=2,ColorId=2,DailyPrice="600",Description="Mercedes",ModelYear = "1998"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice="200",Description="Mazda",ModelYear = "1998"},
                new Car{Id=5,BrandId=4,ColorId=4,DailyPrice="100",Description="Opel",ModelYear = "1998"},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            var deleteCar = _car.SingleOrDefault(x => x.Id == car.Id);
            _car.Remove(deleteCar);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int brandId)
        {
            var idSelect = _car.Where(x => x.BrandId == brandId).ToList();
            return idSelect;
        }

        public void Update(Car car)
        {
            var updateCar = _car.SingleOrDefault(x => x.Id == car.Id);
            updateCar.ModelYear = car.ModelYear; 
        }
    }
}
