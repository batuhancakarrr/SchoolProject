using School.Data.Entities.Concrete.Schools;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;

namespace Repository.Abstracts;
public interface ISchoolRepository : IRepository<EntitySchool> {
	List<Student> GetStudentsBySchoolId(int schoolId);
}

