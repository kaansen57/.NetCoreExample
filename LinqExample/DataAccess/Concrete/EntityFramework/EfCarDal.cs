using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDTO> GetCarDetails()
        {
            using (CarContext carContext = new CarContext())
            {
                var details = from c in carContext.Car
                              join b in carContext.Brand
                              on c.BrandId equals b.BrandId
                              join co in carContext.Color
                              on c.ColorId equals co.ColorId
                              select new CarDTO { BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice };
                return details.ToList();
            }
            
        }

    }

}
