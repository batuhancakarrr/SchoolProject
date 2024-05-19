using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities;

namespace Repository.Concretes {
	public class StudentRepository : Repository<Student>, IStudentRepository {
		private readonly SchoolContext _context;

		public StudentRepository(SchoolContext context) : base(context) {
			_context = context;
		}
		public List<Student> GetStudentsWithClassAndSchool() {
			return _context.Students
						   .Include(s => s.Class)
						   .ThenInclude(c => c.School)
						   .ToList();
		}
		public Student GetByIdWithClassAndSchool(int id) {
			return _context.Students
						   .Where(x => x.Id == id)
						   .Include(s => s.Class)
						   .ThenInclude(c => c.School)
						   .FirstOrDefault();
		}

		public List<Student> ListWithClassAndSchool() {
			return _context.Students.Include(x => x.Class).ThenInclude(x => x.School).ToList();
		}
		public List<Student> GetStudentsByClassId(int id) {
			return _context.Students.Where(s => s.ClassId == id).ToList();
		}
	}
}
