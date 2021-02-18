using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        List<Brand> _brand;
        List<Color> _color;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=300,Description="Audi",ModelYear = "1998"},
                new Car{Id=2,BrandId=2,ColorId=1,DailyPrice=500,Description="Mercedes",ModelYear = "1998"},
                new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=600,Description="Mercedes",ModelYear = "1998"},
                new Car{Id=4,BrandId=3,ColorId=3,DailyPrice=200,Description="Mazda",ModelYear = "1998"},
                new Car{Id=5,BrandId=4,ColorId=4,DailyPrice=100,Description="Opel",ModelYear = "1998"},
            };

            _brand = new List<Brand>
            {
                new Brand{BrandId = 1 , BrandName = "Audi"},
                new Brand{BrandId = 2 , BrandName = "Mercedes"},
                new Brand{BrandId = 3 , BrandName = "Mazda"},
                new Brand{BrandId = 3 , BrandName = "Opel"}
            };

            _color = new List<Color>
            {
                new Color{ColorId = 1 , ColorName = "Beyaz"},
                new Color{ColorId = 2 , ColorName = "Kırmızı"},
                new Color{ColorId = 3 , ColorName = "Siyah"},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void BrandColorGet()
        {
            var result = from p in _car
                         join b in _brand 
                         on p.BrandId equals b.BrandId
                         join c in _color 
                         on p.ColorId equals c.ColorId
                         select new CarDTO { BrandName = b.BrandName , ColorName = c.ColorName , DailyPrice = p.DailyPrice};
        }

        public void Delete(Car car)
        {
            var deleteCar = _car.SingleOrDefault(x => x.Id == car.Id);
            _car.Remove(deleteCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            var idSelect = _car.Where(x => x.BrandId == brandId).ToList();
            return idSelect;
        }

        public List<CarDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var updateCar = _car.SingleOrDefault(x => x.Id == car.Id);
            updateCar.ModelYear = car.ModelYear;
        }

        
    }
}
