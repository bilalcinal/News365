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
        var resultList = await _categoryDal.GetListAsync(x => x.Id == null);
        return new SuccessDataResult<List<Category>>(resultList.ToList());
    }
}
