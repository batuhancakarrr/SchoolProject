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

    public Result<ClassTeacherDTO> AddTeacherToClass(int classId, int teacherId) {
        Result<ClassTeacherDTO> result = new();
        try {
            ClassTeacher teacher = _classTeacherRepository.AddTeacherToClass(classId, teacherId);
            result.Data = Mapping.Mapper.Map<ClassTeacherDTO>(teacher);
        }
        catch (Exception ex) {
            result.Success = false;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
}
