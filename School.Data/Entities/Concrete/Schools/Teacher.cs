using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities.Concrete.Schools;
public class Teacher : BaseEntity {
	[MaxLength(50), Required]
	public string Name { get; set; }
	[MaxLength(50), Required]
	public string Branch { get; set; }
	[MaxLength(50), Required]
	public string Username { get; set; }

	[MaxLength(50), Required]
	public string Password { get; set; }
	public ICollection<ClassTeacher> ClassTeachers { get; set; }

}
