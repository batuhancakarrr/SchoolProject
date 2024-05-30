using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.ServiceHelper.Abstracts;

public interface IClassService : IService<Class, ClassDTO> {
	Result<List<ClassDTO>> ListWithSchool();
}
