using School.Data.Entities.Concrete.Schools;

namespace Repository.Abstracts;

public interface ITeacherRepository : IRepository<Teacher> {
    List<ClassTeacher> GetClassesByTeacherId(int teacherId);
    Task<Teacher> Login(string username, string password);

}
