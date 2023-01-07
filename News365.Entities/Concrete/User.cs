using System.ComponentModel.DataAnnotations;
using News365.Core.Entities;

namespace News365.Entities.Concrete;

public class User : IEntity
{
    [Key]
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
