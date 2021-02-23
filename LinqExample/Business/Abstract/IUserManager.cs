using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserManager
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        IDataResult<List<User>> GetAllList();

        IDataResult<User> GetCustomer(int userId);
    }
}
