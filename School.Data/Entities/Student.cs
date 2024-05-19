using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities;
public class Student : BaseEntity {
	[MaxLength(50), Required]
	public string Name { get; set; }

	[ForeignKey("Class")]
	public int ClassId { get; set; }
	public Class Class { get; set; }
	[MaxLength(50), Required]
	public string Username { get; set; }

	[MaxLength(50), Required]
	public string Password { get; set; }
}
