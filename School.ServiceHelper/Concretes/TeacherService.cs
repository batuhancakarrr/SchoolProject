using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;

namespace School.Service.Concretes;

public class TeacherService : Service<Teacher, TeacherDTO>, ITeacherService {
	private readonly ITeacherRepository _teacherRepository;

	public TeacherService(ITeacherRepository teacherRepository) : base(teacherRepository) {
		_teacherRepository = teacherRepository;
	}

	public Result<List<ClassTeacherDTO>> GetClassesByTeacherId(int teacherId) {
		Result<List<ClassTeacherDTO>> result = new();
		try {
			List<ClassTeacher> classes = _teacherRepository.GetClassesByTeacherId(teacherId);
			result.Data = Mapping.Mapper.Map<List<ClassTeacherDTO>>(classes);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
	public async Task<Result<TeacherDTO>> Login(string username, string password) {
		Result<TeacherDTO> result = new();
		try {
			Teacher teacher = await _teacherRepository.Login(username, password);
			if (teacher != null) {
				result.Data = Mapping.Mapper.Map<TeacherDTO>(teacher);
			}
			else {
				result.Success = false;
				result.ErrorMessage = "Öğretmen kullanıcı adı veya şifre yanlış";
			}
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
}
