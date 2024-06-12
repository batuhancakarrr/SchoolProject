using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Result;
using School.ServiceHelper.Abstracts;

namespace School.ServiceHelper.Concretes;

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

    public Result<bool> Add(TeacherDTO teacherDTO) {
        Result<bool> result = new();
        try {
            Teacher teacher = Mapping.Mapper.Map<Teacher>(teacherDTO);
            teacher.Username = teacher.Name;
            teacher.Password = "123";
            _teacherRepository.Insert(teacher);
            result.Data = true;
            result.Message = "Öğrenci başarıyla eklendi.";
        }
        catch (Exception ex) {
            result.Success = false;
            result.ErrorMessage = ex.Message;
        }
        return result;
    }
    public Result<bool> Update(int id, string name, string branch) {
        Result<bool> result = new();
        try {
            Teacher teacher = _teacherRepository.GetById(id, false);
            if (teacher == null) {
                return new Result<bool>(false, "Öğrenci bulunamadı.");
            }

            teacher.Name = name;
            teacher.Branch = branch;

            _teacherRepository.Update(teacher);
            result.Data = true;
            result.Message = "Öğrenci başarıyla güncellendi.";
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
