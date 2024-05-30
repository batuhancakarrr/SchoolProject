using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;

namespace School.ServiceHelper.Abstracts;

public interface ISchoolService : IService<EntitySchool, SchoolDTO> {
	Result<List<StudentDTO>> GetStudentsBySchoolId(int schoolId);
}
