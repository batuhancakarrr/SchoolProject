using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities;
public class ClassTeacher {

	[ForeignKey("Class")]
	public int ClassId { get; set; }
	public Class Class { get; set; }

	[ForeignKey("Teacher")]
	public int TeacherId { get; set; }
	public Teacher Teacher { get; set; }
}
