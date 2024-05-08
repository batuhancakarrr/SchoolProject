using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
namespace School.Data.Entities;
public class School : BaseEntity {
	[MaxLength(50), Required]
	public string Name { get; set; }
	[MaxLength(400), Required]
	public string Address { get; set; }
}
