using News365.Core.Entities;

namespace News365.Entities.Concrete;

public class NewsModel : Entity
{
     public int CategoryId { get; set; }
     public string Title { get; set; }
     public string Body { get; set; }
     public string FileCode { get; set; }
     public DateTime DateTime { get; set; }
}
