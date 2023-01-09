using News365.Core.Entities;

namespace News365.Entities.Concrete;

public class Page : Entity
{
    public int PageId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileCodeCenterLeft { get; set; }
    public string FileCodeCenter { get; set; }
    public string FileCodeCenterRight { get; set; }
    public string SlugUrl { get; set; }
   
   
}