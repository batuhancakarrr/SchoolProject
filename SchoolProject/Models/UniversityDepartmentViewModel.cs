using School.Data.Entities.Concrete.University;

namespace SchoolProject.Models;

public class UniversityDepartmentViewModel {
	public IEnumerable<University> Universities { get; set; }
	public IEnumerable<Department> Departments { get; set; }
}
