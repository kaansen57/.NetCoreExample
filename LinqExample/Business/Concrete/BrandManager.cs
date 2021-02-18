using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandManager
    {
        private IBrandDal _brand;

        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }
        public void Add(Brand brand)
        {
            _brand.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brand.Delete(brand);
        }

        public List<Brand> GetAllList()
        {
            return _brand.GetAll();
        }

        public Brand GetBrand(int brandId)
        {
          return  _brand.Get(b  => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            _brand.Update(brand);
        }
    }
}
