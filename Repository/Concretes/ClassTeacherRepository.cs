using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;

namespace Repository.Concretes;
public class ClassTeacherRepository : Repository<ClassTeacher>, IClassTeacherRepository {
    private readonly SchoolContext _context;
    public ClassTeacherRepository(SchoolContext context) : base(context) {
        _context = context;
    }
    public ClassTeacher AddTeacherToClass(int classId, int teacherId) {
        ClassTeacher classTeacher = new() {
            ClassId = classId,
            TeacherId = teacherId
        };

        _context.ClassTeachers.Add(classTeacher);
        _context.SaveChanges();

        return classTeacher;
    }
}
