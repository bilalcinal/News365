using News365.Business.Abstract;
using News365.Business.Contants;
using News365.Core.Utilities.Result;
using News365.DataAccess.Abstract;
using News365.Entities.Concrete;

namespace News365.Business.Concrete;

public class CategoryManager : ICategoryService
{
   private readonly ICategoryDal _categoryDal;

   public CategoryManager(ICategoryDal categoryDal)
   {
     _categoryDal = categoryDal;
   }

    public async Task<IDataResult<Category>> AddAsync(Category category)
    {
          category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
          await  _categoryDal.AddAsync(category);
          return new SuccessDataResult<Category>(category, Messages.AddMessage);

    }

     public async Task<IDataResult<List<Category>>> GetCategoryListAsync()
    {
        var resultList = await _categoryDal.GetListAsync();
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }

     public async Task<IResult> UpdateAsync(Category category)
    {
        category.SlugUrl = UrlSeoHelper.UrlSeo(category.SlugUrl);
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
    }
     public async Task<IResult> RemoveAsync(Category category)
     {
        await _categoryDal.RemoveAsync(category);
        return new SuccessResult(Messages.UpdateMessage);
     }
     public async Task<IDataResult<Category>> GetByCategoryIdAsync(Guid CategoryId)
    {
        var result = await _categoryDal.GetFirstOrDefaultAsync(x => x.Id == CategoryId);
        return result != null ? new SuccessDataResult<Category>(result) : new ErrorDataResult<Category>(Messages.RecordMessage);
    }
}
