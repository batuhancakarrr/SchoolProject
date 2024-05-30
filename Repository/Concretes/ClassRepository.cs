using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using Repository.Concretes;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;

public class ClassRepository : Repository<Class>, IClassRepository {
	private readonly SchoolContext _context;

	public ClassRepository(SchoolContext context) : base(context) {
		_context = context;
	}
	public List<Class> ListWithSchool() {
		return _context.Classes.Include(x => x.School).ToList();
	}

	// TODO: if else ile tracking ekle
	public override Class GetById(int id, bool withTracking) {
		return _context.Classes
			.Include(c => c.Students)
			.Include(c => c.ClassTeachers)
			.ThenInclude(ct => ct.Teacher)
			.FirstOrDefault(c => c.Id == id);
	}
}
