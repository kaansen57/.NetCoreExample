using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserManager
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);

        List<User> GetAllList();

        User GetCustomer(int userId);
    }
}
