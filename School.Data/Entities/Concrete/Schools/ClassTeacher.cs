using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities.Concrete.Schools;
public class ClassTeacher : BaseEntity {

	[ForeignKey("Class")]
	public int ClassId { get; set; }
	public Class Class { get; set; }

	[ForeignKey("Teacher")]
	public int TeacherId { get; set; }
	public Teacher Teacher { get; set; }
}
