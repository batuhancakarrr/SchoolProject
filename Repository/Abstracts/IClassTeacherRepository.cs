using School.Data.Entities.Concrete.Schools;

namespace Repository.Abstracts;
public interface IClassTeacherRepository : IRepository<ClassTeacher> {

    ClassTeacher AddTeacherToClass(int classId, int teacherId);

}
