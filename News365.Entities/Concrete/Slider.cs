using News365.Core.Entities;

namespace News365.Entities.Concrete;

public class Slider : Entity
{
    public int SliderId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileCode { get; set; }
    public string SlugUrl { get; set; }

}
