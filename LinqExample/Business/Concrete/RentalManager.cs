using Business.Abstract;
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

        public void Add(Rental rental)
        {
            _rentalDal.Add(rental);
        }

        public void Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
        }

        public List<Rental> GetAllList()
        {
            return _rentalDal.GetAll();
        }

        public Rental GetRental(int rentalId)
        {
            return _rentalDal.Get(r => r.Id == rentalId);
        }

        public void Update(Rental rental)
        {
            rental.RentDate = DateTime.Now;
            _rentalDal.Update(rental);
        }
    }
}
