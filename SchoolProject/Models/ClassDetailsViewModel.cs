using School.Data.Entities.Concrete.Schools;
namespace SchoolProject.Models;

public class ClassDetailsViewModel {
	public List<Student> Students { get; set; }
	public List<ClassTeacher> ClassTeachers { get; set; }
}
