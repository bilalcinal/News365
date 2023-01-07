using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.DataAccess.Abstract;
using News365.Entities.Concrete;

namespace News365.Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserManager(IUserDal userDal, IHttpContextAccessor httpContextAccessor)
    {
        _userDal = userDal;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<IDataResult<User>> SignInAsync(User user)
    {
        var row = await _userDal.GetFirstOrDefaultAsync(x => x.Email == user.Email.Trim() && x.Password == user.Password.Trim());
        if (row != null)
        {
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, row.FullName),
                new Claim(ClaimTypes.Email, row.Email),
                new Claim(ClaimTypes.Role, row.Role)
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            bool isAuthenticated = true;
            var principal = new ClaimsPrincipal(identity);
            if (isAuthenticated)
            {
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    IsPersistent = true,
                    AllowRefresh = false
                });
                return new SuccessDataResult<User>(row, Messages.SuccesfulLogin);
            }
        }
        return new ErrorDataResult<User>(new User(), Messages.UserNotFound);
    }
}
