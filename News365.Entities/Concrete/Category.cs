using News365.Core.Entities;

namespace News365.Entities.Concrete;

    public class Category : Entity
    {
      public Category()
    {
        
      NewsModels = new HashSet<NewsModel>();
    }
       public string Name { get; set; }
       public string SlugUrl { get; set; }
       
      public virtual ICollection<NewsModel> NewsModels { get; set; }

    }
