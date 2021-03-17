﻿using Business.Abstract;
using Core.Utilities.Results;
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
        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult();
        }

        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult();
        }

       public IDataResult<List<Brand>> GetAll()
        {
            var data = _brand.GetAll();
            return new SuccessDataResult<List<Brand>>(data);
        }

       

        public IDataResult<Brand> GetBrand(int brandId)
        {
             var data = _brand.Get(b => b.BrandId == brandId);
             return new SuccessDataResult<Brand>(data);
        }

       
    }
}
