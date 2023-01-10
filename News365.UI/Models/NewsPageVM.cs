using News365.Entities.Concrete;

namespace News365.UI.Models;

public class NewsPageVM
{
    public Category Category { get; set; }
    public List<NewsModel> News { get; set; }
}