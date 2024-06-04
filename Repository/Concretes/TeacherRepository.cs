using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;

namespace Repository.Concretes;

public class TeacherRepository : Repository<Teacher>, ITeacherRepository {
    private readonly SchoolContext _context;

    public TeacherRepository(SchoolContext context) : base(context) {
        _context = context;
    }

    public List<ClassTeacher> GetClassesByTeacherId(int teacherId) {
        return _context.ClassTeachers
                       .Include(x => x.Teacher)
                       .Include(x => x.Class)
                       .ThenInclude(x => x.School)
                       .Where(x => x.TeacherId == teacherId)
                       .ToList();
    }
    public async Task<Teacher> Login(string username, string password) {
        return await _context.Teachers.SingleOrDefaultAsync(s => s.Username == username && s.Password == password);
    }
}
