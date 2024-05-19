using School.Data.Entities;
using EntitySchool = School.Data.Entities.School;

namespace Repository.Abstracts;
public interface ISchoolRepository : IRepository<EntitySchool> {
	List<Student> GetStudentsBySchoolId(int schoolId);
}

