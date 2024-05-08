using School.Data.Entities;
using EntitySchool = School.Data.Entities.School;
namespace SchoolProject.Models;

public class ClassDetailsViewModel {
	public List<Student> Students { get; set; }
	public List<ClassTeacher> ClassTeachers { get; set; }
	public List<Teacher> Teachers { get; set; }
	public List<Class> Classes { get; set; }
	public List<EntitySchool> Schools { get; set; }
}
