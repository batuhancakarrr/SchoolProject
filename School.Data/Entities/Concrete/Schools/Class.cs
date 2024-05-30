using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities.Concrete.Schools;
public class Class : BaseEntity {
	public int Degree { get; set; }

	[MaxLength(50), Required]
	public string Name { get; set; }

	[ForeignKey("School")]
	public int SchoolId { get; set; }
	public School School { get; set; }
	public ICollection<Student> Students { get; set; }
	public ICollection<ClassTeacher> ClassTeachers { get; set; }
}