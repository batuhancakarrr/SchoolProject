using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Abstracts;

public interface IClassService : IService<Class, ClassDTO> {
	Result<List<ClassDTO>> ListWithSchool();
}
