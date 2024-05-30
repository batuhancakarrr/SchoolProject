using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.ServiceHelper.Abstracts;

public interface ITeacherService : IService<Teacher, TeacherDTO> {
	Result<List<ClassTeacherDTO>> GetClassesByTeacherId(int teacherId);
	Task<Result<TeacherDTO>> Login(string username, string password);

}
