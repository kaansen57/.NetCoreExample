using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        IUserDal _userDal;
        public UserManager(IUserDal user)
        {
            _userDal = user;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAllList()
        {
            return _userDal.GetAll();
        }

        public User GetCustomer(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
        }

        public void Update(User user)
        {
            user.Password = "000000";
            _userDal.Update(user);
        }

    }
}
