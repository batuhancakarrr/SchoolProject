using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.ServiceHelper.Abstracts;
public interface IClassTeacherService : IService<ClassTeacher, ClassTeacherDTO> {
	Result<List<ClassTeacher>> GetClassTeachersByClassId(int classId);
}

