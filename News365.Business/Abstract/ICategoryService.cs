using News365.Core.Utilities.Result;
using News365.Entities.Concrete;

namespace News365.Business.Abstract;

public interface ICategoryService
{
Task<IDataResult<Category>> GetByCategoryIdAsync(Guid CategoryId);
Task<IDataResult<Category>> AddAsync(Category category);
Task<IDataResult<List<Category>>> GetCategoryListAsync();
Task<IResult> UpdateAsync(Category category);
Task<IResult> DeleteAsync(Category category);
}
