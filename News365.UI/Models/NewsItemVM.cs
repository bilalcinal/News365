using News365.Entities.Concrete;

namespace News365.UI.Models;

public class NewsItemVM
{ 
    public NewsModel News { get; set; }
    public List<NewsModel> OtherNews { get; set; }

}
