using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;

namespace Repository.Concretes;
public class ClassTeacherRepository : Repository<ClassTeacher>, IClassTeacherRepository {
	private readonly SchoolContext _context;
	public ClassTeacherRepository(SchoolContext context) : base(context) {
		_context = context;
	}
	public List<ClassTeacher> GetClassTeachersByClassId(int classId) {
		return _context.ClassTeachers.Include(ct => ct.Teacher).Where(ct => ct.ClassId == classId).ToList();
	}
}
