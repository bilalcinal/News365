using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.DataAccess.Abstract;
using News365.Entities.Concrete;

namespace News365.Business.Concrete;

public class NewsManager : INewsService
{
    private readonly INewsDal _newsDal;

    public NewsManager(INewsDal newsDal)
    {
        _newsDal = newsDal;
    }
    public async Task<IDataResult<NewsModel>> AddAsync(NewsModel newsModel)
    {
        newsModel.SlugUrl = UrlSeoHelper.UrlSeo(newsModel.SlugUrl);
        await _newsDal.AddAsync(newsModel);
        return new SuccessDataResult<NewsModel>(newsModel, Messages.AddMessage);
    }

    public async Task<IDataResult<NewsModel>> GetByNewsModelIdAsync(Guid NewsId)
    {
        var result = await _newsDal.GetFirstOrDefaultAsync(x => x.Id == NewsId);
        return result != null ? new SuccessDataResult<NewsModel>(result) : new ErrorDataResult<NewsModel>(Messages.RecordMessage);

    }

    public  async Task<IDataResult<List<NewsModel>>> GetNewsListAsync()
    {
        var resultList = await _newsDal.GetListAsync();
        return new SuccessDataResult<List<NewsModel>>(resultList.ToList());
    }

    public async Task<IResult> RemoveAsync(NewsModel newsModel)
    {
         await _newsDal.RemoveAsync(newsModel);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> UpdateAsync(NewsModel newsModel)
    {
        newsModel.SlugUrl = UrlSeoHelper.UrlSeo(newsModel.SlugUrl);
        await _newsDal.UpdateAsync(newsModel);
        return new SuccessResult(Messages.UpdateMessage);
    }
}
