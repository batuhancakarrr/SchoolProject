using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities.Concrete.University;
public class Department {
	public int Id { get; set; }
	[MaxLength(200), Required]
	public string Name { get; set; }
}
