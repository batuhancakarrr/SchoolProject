using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Repository.Abstracts;
using School.Service.Abstracts;
using School.Service.Result;

namespace School.Service.Concretes;
public class AdminService : Service<Admin, AdminDTO>, IAdminService {
	private readonly IAdminRepository _adminRepository;
	public AdminService(IAdminRepository adminRepository) : base(adminRepository) {
		_adminRepository = adminRepository;
	}
	public async Task<Result<AdminDTO>> Login(string username, string password) {
		Result<AdminDTO> result = new();
		try {
			Admin admin = await _adminRepository.Login(username, password);
			if (admin != null) {
				result.Data = Mapping.Mapper.Map<AdminDTO>(admin);
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
