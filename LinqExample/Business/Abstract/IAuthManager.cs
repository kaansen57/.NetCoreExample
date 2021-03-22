using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTO_s;

namespace Business.Abstract
{
    public interface IAuthManager
    {
        IDataResult<UserJWT> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<UserJWT> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UserJWT user);
    }
}
