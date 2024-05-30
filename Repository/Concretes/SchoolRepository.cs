using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;

namespace Repository.Concretes;
public class SchoolRepository : Repository<EntitySchool>, ISchoolRepository {
	private readonly SchoolContext _context;

	public SchoolRepository(SchoolContext context) : base(context) {
		_context = context;
	}
	public List<Student> GetStudentsBySchoolId(int schoolId) {
		return _context.Students
			.Include(s => s.Class)
			.ThenInclude(c => c.School)
			.Where(s => s.Class.SchoolId == schoolId)
			.ToList();
	}
	public override List<EntitySchool> List() {
		return _context.Schools
			.Include(s => s.District)
			.ThenInclude(c => c.City)
			.ToList();
	}
}
