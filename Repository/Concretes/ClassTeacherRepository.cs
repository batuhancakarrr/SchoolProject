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
    public List<ClassTeacher> AddTeacherToClass(int classId, int[] teacherIds) {
        List<ClassTeacher> classTeachers = [];
        foreach (int teacherId in teacherIds) {
            ClassTeacher classTeacher = new() {
                ClassId = classId,
                TeacherId = teacherId
            };
            classTeachers.Add(classTeacher);
        }
        _context.ClassTeachers.AddRange(classTeachers);
        _context.SaveChanges();
        return classTeachers;
    }
    public List<ClassTeacher> GetAvailableTeachers(int classId) {
        return _context.ClassTeachers
            .Where(c => c.ClassId == classId)
            .Include(ct => ct.Teacher)
            .ToList();
    }
}
