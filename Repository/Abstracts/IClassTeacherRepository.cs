using School.Data.Entities;

namespace Repository.Abstracts;
public interface IClassTeacherRepository : IRepository<ClassTeacher> {

	List<ClassTeacher> GetClassTeachersByClassId(int classId);

}
