using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        IBrandManager _brandManager;
      

        //bir entity manager kendi yapısındaki dal hariç başka yapıyı enjekte edemez
        //dependecy enjection
        public CarManager(ICarDal carDal , IBrandManager brandManager)
        {
            _carDal = carDal;
            _brandManager = brandManager;
         
        }
        [SecuredOperation("Admin,User")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
         IResult result = BusinessRule.Run(
                CheckBrandCountCorrect(car.BrandId)
                ,CheckDuplicateCarName(car.CarName)
                 ,CheckBrandLimit()
                );
        
            if (result != null)
            {
                return result;
            }
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
      
         private IResult CheckBrandCountCorrect(int brandId)
        {
              
            var result = _carDal.GetAll(x => x.BrandId == brandId).Count;
            if (result > 2)
            {
                return new ErrorResult("2den fazla brand idye kayıtlı");
            }
            return new SuccessResult();
        }

        private IResult CheckDuplicateCarName(string carName)
        {
            //var result = _carDal.GetAll(x => x.CarName == carName).Any(); 
            // eğer böyle belirtilen kriterde data varsa true döner
            var result = _carDal.GetAll(x => x.CarName == carName).Count;
            if (result>0)
            {
                return new ErrorResult("Aynı isimde data mevcut");
            }
            return new SuccessResult();
        }

        private IResult CheckBrandLimit()
        {
            var result = _brandManager.GetAll().Data.Count;
            if (result > 10)
            {
                return new ErrorResult("Marka limiti aşıldı");
            }
            return new SuccessResult();
        }

    }
}
