using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        void Add(Rental rental);
        void Delete(Rental rental);
        void Update(Rental rental);

        List<Rental> GetAllList();

        Rental GetRental(int rentalId);
    }
}
