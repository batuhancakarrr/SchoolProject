using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.ServiceHelper.Result;

namespace School.ServiceHelper.Abstracts;
public interface IAdminService : IService<Admin, AdminDTO> {
	Task<Result<AdminDTO>> Login(string username, string password);
}
