using School.Data.Entities.Concrete.Schools;

namespace Repository.Abstracts;
public interface IClassTeacherRepository : IRepository<ClassTeacher> {

	List<ClassTeacher> GetClassTeachersByClassId(int classId);

}
