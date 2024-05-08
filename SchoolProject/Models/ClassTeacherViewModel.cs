using School.Data.Entities;

namespace SchoolProject.Models;

public class ClassTeacherViewModel {
    public List<ClassTeacher> ClassTeachers { get; set; }

    public Teacher Teacher { get; set; }
}
