using Core.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserJwtDal : IEntityRepository<UserJWT>
    {
        List<OperationClaim> GetClaims(UserJWT user);
    }
}
