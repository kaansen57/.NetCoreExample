using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserJwtManager
    {
        List<OperationClaim> GetClaims(UserJWT user);
        void Add(UserJWT user);
        UserJWT GetByMail(string email);
        
    }
}
