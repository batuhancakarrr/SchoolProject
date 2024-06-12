using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Abstracts;
public interface IStudentService : IService<Student, StudentDTO> {
	Result<List<StudentDTO>> GetStudentsWithClassAndSchool();
	Result<StudentDTO> GetByIdWithClassAndSchool(int id);
	Result<List<StudentDTO>> ListWithClassAndSchool();
	Result<List<StudentDTO>> GetStudentsByClassId(int id);
	Result<bool> Add(StudentDTO student);
	Result<bool> Update(int id, string name, int classId);
	Task<Result<StudentDTO>> Login(string username, string password);
}