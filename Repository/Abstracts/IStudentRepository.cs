using School.Data.Entities;

namespace Repository.Abstracts {
	public interface IStudentRepository : IRepository<Student> {
		List<Student> GetStudentsWithClassAndSchool();
		Student GetByIdWithClassAndSchool(int id);
		List<Student> ListWithClassAndSchool();
		List<Student> GetStudentsByClassId(int id);

	}
}
