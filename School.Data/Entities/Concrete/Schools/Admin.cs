using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities.Concrete.Schools;
public class Admin : BaseEntity {
	[MaxLength(50), Required]
	public string Name { get; set; }
	[MaxLength(50), Required]
	public string Username { get; set; }
	[MaxLength(50), Required]
	public string Password { get; set; }
}
