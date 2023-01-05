using Autofac;
using News365.Business.Abstract;
using News365.Business.Concrete;
using News365.DataAccess.Abstract;
using News365.DataAccess.Concrete;
using News365.DataAccess.Concrete.EntityFramework;

namespace News365.Business.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region Category
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        #endregion Category

        #region News
        builder.RegisterType<NewsManager>().As<INewsService>();
        builder.RegisterType<EfNewsDal>().As<INewsDal>();
        #endregion

       #region Document
        builder.RegisterType<DocumentManager>().As<IDocumentService>();
        builder.RegisterType<EfDocumentDal>().As<IDocumentDal>();
        #endregion
    }   
}
