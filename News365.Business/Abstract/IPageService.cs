using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;

public interface IPageService
{
    Task<IDataResult<Page>> GetByPageIdAsync(Guid PageId);
    Task<IDataResult<List<Page>>> GetPageListAsync();
    Task<IDataResult<Page>> AddAsync(Page page);
    Task<IResult> UpdateAsync(Page page);
    Task<IResult> RemoveAsync(Page page);
  
}
