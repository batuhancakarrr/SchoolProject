using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Service.Result;

namespace School.Service.Abstracts;
public interface IAdminService : IService<Admin, AdminDTO> {
	Task<Result<AdminDTO>> Login(string username, string password);
}
