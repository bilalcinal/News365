using News365.DataAccess.Abstract;
using News365.DataAccess.Concrete.Context;
using News365.DataAccess.Concrete.EntityFramework;
using News365.Entities.Concrete;

namespace News365.DataAccess.Concrete;

public class EfNewsDal : EfEntityRepositoryBaseAsync<NewsModel, News365DbContext>, INewsDal
{

}
