using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities.Concrete.University;
public class UniversityDepartment {
	[ForeignKey("University")]
	public int UniversityId { get; set; }
	public University University { get; set; }
	[ForeignKey("Department")]
	public int DepartmentId { get; set; }
	public Department Department { get; set; }
}

