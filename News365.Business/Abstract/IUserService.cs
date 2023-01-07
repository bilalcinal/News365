using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;
public interface IUserService
{
   Task<IDataResult<User>> SignInAsync(User user);
}
