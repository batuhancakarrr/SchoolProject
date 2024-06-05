using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.ServiceHelper.Abstracts;
public interface IClassTeacherService : IService<ClassTeacher, ClassTeacherDTO> {
    Result<List<ClassTeacherDTO>> AddTeacherToClass(int classId, int[] teacherIds);
    Result<List<ClassTeacherDTO>> GetAvailableTeachers(int classId);
}

