using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result.ReturnDate != null && result.ReturnDate < rental.RentDate)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Kiralama Yapıldı!");
            }
            return new ErrorResult("Kiralama Yapılamadı! Araç filoda değil !");
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult("SİLİNDİ");
        }

        public IResult Update(Rental rental)
        {
            rental.RentDate = DateTime.Now;
            _rentalDal.Update(rental);
            return new SuccessResult("GÜNCELLENDİ");
        }
        public IDataResult<List<Rental>> GetAllList()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ProductList);
        }

        public IDataResult<Rental> GetRental(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == rentalId));
        }

       
    }
}
