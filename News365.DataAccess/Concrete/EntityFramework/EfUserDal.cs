using News365.DataAccess.Abstract;
using News365.DataAccess.Concrete.Context;
using News365.Entities.Concrete;

namespace News365.DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBaseAsync<User, News365DbContext>, IUserDal
{

}
