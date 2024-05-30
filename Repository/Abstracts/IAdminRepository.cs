using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;

namespace School.Repository.Abstracts;
public interface IAdminRepository : IRepository<Admin> {
	Task<Admin> Login(string username, string password);
}
