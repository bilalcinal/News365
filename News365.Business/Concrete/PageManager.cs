using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.DataAccess.Abstract;
using News365.Entities.Concrete;

namespace News365.Business.Concrete;

public class PageManager : IPageService
{
     private readonly IPageDal _pageDal;
    public PageManager(IPageDal pageDal)
    {
        _pageDal = pageDal;
    }
    public async Task<IDataResult<Page>> AddAsync(Page page)
    {
        await _pageDal.AddAsync(page);
        return new SuccessDataResult<Page>(page, Messages.AddMessage);
    }
   

    public async Task<IDataResult<Page>> GetByPageIdAsync(Guid PageId)
    {
          var row = await _pageDal.GetFirstOrDefaultAsync(x => x.Id == PageId);
        if (row != null)
        {
            return new SuccessDataResult<Page>(row);
        }
        return new ErrorDataResult<Page>(new Page(), Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Page>>> GetPageListAsync()
    {
        var resultList = await _pageDal.GetListAsync();
        return new SuccessDataResult<List<Page>>(resultList.ToList());
    }
    public async Task<IResult> UpdateAsync(Page page)
    {
        await _pageDal.UpdateAsync(page);
        return new SuccessResult(Messages.UpdateMessage);
    }
     public async Task<IResult> RemoveAsync(Page page)
    {
        await _pageDal.RemoveAsync(page);
        return new SuccessResult(Messages.DeleteMessage);
    }

    
}
