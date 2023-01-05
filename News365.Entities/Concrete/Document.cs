using System.ComponentModel.DataAnnotations;
using News365.Core.Entities;

namespace News365.Entities.Concrete;

public class Document : IEntity
{
    [Key]
    public string DocumentUnique { get; set; }
    public string DocumentName { get; set; }
    public string DocumentType { get; set; }
    public string DocumentSize { get; set; }
    public string DocumentFolderName { get; set; }
    public string Storage_Url { get; set; }
    public string Image_Url { get; set; } = " ";
    public string Video_Url { get; set; } = " ";
    public DateTime CreateDate { get; set; }
}
