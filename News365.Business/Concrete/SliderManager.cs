using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.DataAccess.Abstract;
using News365.Entities.Concrete;

namespace News365.Business.Concrete;
public class SliderManager : ISliderService
{
    private readonly ISliderDal _SliderDal;
    public SliderManager(ISliderDal SliderDal)
    {
        _SliderDal = SliderDal;
    }
    public async Task<IDataResult<Slider>> AddAsync(Slider slider)
    {
        slider.SlugUrl = UrlSeoHelper.UrlSeo(slider.SlugUrl);
        await _SliderDal.AddAsync(slider);
        return new SuccessDataResult<Slider>(slider, Messages.AddMessage);
    }

    public async Task<IDataResult<Slider>> GetBySliderIdAsync(Guid SliderId)
    {
        var row = await _SliderDal.GetFirstOrDefaultAsync(x => x.Id == SliderId);
        if (row != null)
        {
            return new SuccessDataResult<Slider>(row);
        }
        return new ErrorDataResult<Slider>(new Slider(), Messages.RecordMessage);
    }

    public async Task<IDataResult<List<Slider>>> GetSliderListAsync()
    {
        var resultList = await _SliderDal.GetListAsync();
        return new SuccessDataResult<List<Slider>>(resultList.ToList());
    }
    public async Task<IResult> UpdateAsync(Slider slider)
    {
        await _SliderDal.UpdateAsync(slider);
        return new SuccessResult(Messages.UpdateMessage);
    }

    public async Task<IResult> RemoveAsync(Slider slider)
    {
         await _SliderDal.RemoveAsync(slider);
        return new SuccessResult(Messages.UpdateMessage);
    }
    
}