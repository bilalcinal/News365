using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;

public interface INewsService
{
    Task<IDataResult<NewsModel>> GetByNewsModelIdAsync(Guid NewsId);
    Task<IDataResult<NewsModel>> AddAsync(NewsModel newsModel);
    Task<IDataResult<List<NewsModel>>> GetNewsListAsync();
    Task<IResult> UpdateAsync(NewsModel newsModel);
    Task<IResult> RemoveAsync(NewsModel newsModel);

}
