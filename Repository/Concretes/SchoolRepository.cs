using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities;
using EntitySchool = School.Data.Entities.School;

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

}
