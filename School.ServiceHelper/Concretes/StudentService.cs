using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service;
using School.Service.Abstracts;
using School.Service.Concretes;
using School.Service.Result;

namespace School.ServiceHelper.Concretes;

public class StudentService : Service<Student, StudentDTO>, IStudentService {
	private readonly IStudentRepository _studentRepository;

	public StudentService(IStudentRepository studentRepository) : base(studentRepository) {
		_studentRepository = studentRepository;
	}

	public Result<List<StudentDTO>> GetStudentsWithClassAndSchool() {
		Result<List<StudentDTO>> result = new();
		try {
			List<Student> students = _studentRepository.GetStudentsWithClassAndSchool();
			result.Data = Mapping.Mapper.Map<List<StudentDTO>>(students);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}

	public Result<StudentDTO> GetByIdWithClassAndSchool(int id) {
		Result<StudentDTO> result = new();
		try {
			Student student = _studentRepository.GetByIdWithClassAndSchool(id);
			result.Data = Mapping.Mapper.Map<StudentDTO>(student);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}

	public Result<List<StudentDTO>> ListWithClassAndSchool() {
		Result<List<StudentDTO>> result = new();
		try {
			List<Student> students = _studentRepository.ListWithClassAndSchool();
			result.Data = Mapping.Mapper.Map<List<StudentDTO>>(students);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}

	public Result<List<StudentDTO>> GetStudentsByClassId(int id) {
		Result<List<StudentDTO>> result = new();
		try {
			List<Student> students = _studentRepository.GetStudentsByClassId(id);
			result.Data = Mapping.Mapper.Map<List<StudentDTO>>(students);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}

	public Result<bool> Add(StudentDTO studentDTO) {
		Result<bool> result = new();
		try {
			Student student = Mapping.Mapper.Map<Student>(studentDTO);
			student.Username = student.Name;
			student.Password = "123";
			_studentRepository.Insert(student);
			result.Data = true;
			result.Message = "Öğrenci başarıyla eklendi.";
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}

	public Result<bool> Update(int id, string name, int classId) {
		Result<bool> result = new();
		try {
			Student student = _studentRepository.GetById(id, false);
			if (student == null) {
				return new Result<bool>(false, "Öğrenci bulunamadı.");
			}

			student.Name = name;
			student.ClassId = classId;

			_studentRepository.Update(student);
			result.Data = true;
			result.Message = "Öğrenci başarıyla güncellendi.";
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
	public async Task<Result<StudentDTO>> Login(string username, string password) {
		Result<StudentDTO> result = new();
		try {
			Student student = await _studentRepository.Login(username, password);
			if (student != null) {
				result.Data = Mapping.Mapper.Map<StudentDTO>(student);
				result.Success = true;
			}
			else {
				result.Success = false;
				result.ErrorMessage = "Öğrenci kullanıcı adı veya şifre yanlış";
			}
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
}

