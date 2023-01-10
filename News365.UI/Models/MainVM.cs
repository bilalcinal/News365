using News365.Entities.Concrete;

namespace News365.UI.Models;

public class MainVM
{
    public List<NewsModel> News { get; set; }
    public List<Page> Pages { get; set; }
    public List<Slider> Sliders { get; set; }
    public List<Category> Categories { get; set; }
}
