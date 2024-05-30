using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;

namespace School.Service.Concretes;

public class SchoolService : Service<EntitySchool, SchoolDTO>, ISchoolService {
	private readonly ISchoolRepository _schoolRepository;

	public SchoolService(ISchoolRepository schoolRepository) : base(schoolRepository) {
		_schoolRepository = schoolRepository;
	}

	public Result<List<StudentDTO>> GetStudentsBySchoolId(int schoolId) {
		Result<List<StudentDTO>> result = new();
		try {
			List<Student> students = _schoolRepository.GetStudentsBySchoolId(schoolId);
			result.Data = Mapping.Mapper.Map<List<StudentDTO>>(students);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
}
