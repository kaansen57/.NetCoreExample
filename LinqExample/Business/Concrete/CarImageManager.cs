using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageManager
    {

        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage entity)
        {
            IResult result = BusinessRule.Run(CheckImageLimit(entity));
            if (result == null)
            {
                _carImageDal.Add(entity);
                return new SuccessResult(Messages.ImageUploadSuccess);
            }
            return result;
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.ImageDeleteSuccess);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.ImageUpdateSuccess);
        }
        public IDataResult<CarImage> Get(int id)
        {
            //var result = _carImageDal.Get(x => x.CarId == id);

            //if (result.ImagePath.Length > 0)
            //{
            //    return new SuccessDataResult<CarImage>(result);
            //}
            return new ErrorDataResult<CarImage>(_carImageDal.Get(x => x.Id == 21));

        }
        public IDataResult<List<CarImage>> GetAllList(int id)
        {
            var result = _carImageDal.GetAll(x => x.CarId == id && x.Id != 21);
            if (result.Count == 0)
            {
                var defaultImage = _carImageDal.GetAll(x => x.Id == 21);
                return new SuccessDataResult<List<CarImage>>(defaultImage);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        private IResult CheckImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageUploadError);
            }
            return new SuccessResult();
        }

    }
}
