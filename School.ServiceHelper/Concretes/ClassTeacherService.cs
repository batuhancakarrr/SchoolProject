using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;

namespace School.Service.Concretes;
public class ClassTeacherService : Service<ClassTeacher, ClassTeacherDTO>, IClassTeacherService {
    private readonly IClassTeacherRepository _classTeacherRepository;
    public ClassTeacherService(IClassTeacherRepository repository) : base(repository) {
        _classTeacherRepository = repository;
    }

    public Result<List<ClassTeacherDTO>> AddTeacherToClass(int classId, int[] teacherIds) {
        Result<List<ClassTeacherDTO>> result = new();
        try {
            List<ClassTeacher> teacher = _classTeacherRepository.AddTeacherToClass(classId, teacherIds);
            result.Data = Mapping.Mapper.Map<List<ClassTeacherDTO>>(teacher);
        }
        catch (Exception ex) {
            result.Success = false;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
    public Result<List<ClassTeacherDTO>> GetAvailableTeachers(int classId) {
        Result<List<ClassTeacherDTO>> result = new();
        try {
            List<ClassTeacher> teacher = _classTeacherRepository.GetAvailableTeachers(classId);
            result.Data = Mapping.Mapper.Map<List<ClassTeacherDTO>>(teacher);
        }
        catch (Exception ex) {
            result.Success = false;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }

}
