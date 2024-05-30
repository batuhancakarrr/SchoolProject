using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service;
using School.Service.Concretes;
using School.Service.Result;
using School.ServiceHelper.Abstracts;

namespace School.ServiceHelper.Concretes;

public class ClassService : Service<Class, ClassDTO>, IClassService {
	private readonly IClassRepository _classRepository;

	public ClassService(IClassRepository classRepository)
		: base(classRepository) {
		_classRepository = classRepository;
	}

	public Result<List<ClassDTO>> ListWithSchool() {
		Result<List<ClassDTO>> result = new();
		try {
			List<Class> classes = _classRepository.ListWithSchool();
			result.Data = Mapping.Mapper.Map<List<ClassDTO>>(classes);
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
}
