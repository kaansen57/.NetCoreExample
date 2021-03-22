using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserJwtManager : IUserJwtManager
    {
        IUserJwtDal _userDal;

        public UserJwtManager(IUserJwtDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(UserJWT user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(UserJWT user)
        {
           _userDal.Add(user);
        }

        public UserJWT GetByMail(string email)
        {   
            return _userDal.Get(u => u.Email == email);
        }
    }
}
