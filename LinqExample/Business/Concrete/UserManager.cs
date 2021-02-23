using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Silindi");
        }
        public IResult Update(User user)
        {
            user.Password = "000000";
            _userDal.Update(user);
            return new SuccessResult("Güncellendi");
        }
        public IDataResult<List<User>> GetAllList()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetCustomer(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.ProductList);
        }

    }
}
