using School.Data.Entities;

namespace Repository.Abstracts {
	public interface ITeacherRepository : IRepository<Teacher> {
		List<ClassTeacher> GetClassesByTeacherId(int teacherId);
	}
}
