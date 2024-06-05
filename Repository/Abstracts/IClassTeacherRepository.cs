using School.Data.Entities.Concrete.Schools;

namespace Repository.Abstracts;
public interface IClassTeacherRepository : IRepository<ClassTeacher> {

    List<ClassTeacher> AddTeacherToClass(int classId, int[] teacherIds);
    List<ClassTeacher> GetAvailableTeachers(int classId);

}
