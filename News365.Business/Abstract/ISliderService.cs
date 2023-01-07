using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;
public interface ISliderService
{
    Task<IDataResult<Slider>> GetBySliderIdAsync(Guid SliderId);
    Task<IDataResult<List<Slider>>> GetSliderListAsync();
    Task<IDataResult<Slider>> AddAsync(Slider slider);
    Task<IResult> UpdateAsync(Slider slider);
    Task<IResult> RemoveAsync(Slider slider);
}