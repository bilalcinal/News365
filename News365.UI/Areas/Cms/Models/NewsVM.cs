using News365.Entities.Concrete;

namespace News365.UI.Areas.Cms.Models;

public class NewsVM
{
   public NewsModel NewsModel { get; set; }
   public List<Category> Categories { get; set; }
}
