using Microsoft.EntityFrameworkCore;
using Repository.Concretes;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;
using School.Repository.Abstracts;

namespace School.Repository.Concretes;
public class AdminRepository : Repository<Admin>, IAdminRepository {
	private readonly SchoolContext _context;
	public AdminRepository(SchoolContext context) : base(context) {
		_context = context;
	}
	public async Task<Admin> Login(string username, string password) {
		return await _context.Admins.SingleOrDefaultAsync(s => s.Username == username && s.Password == password);
	}

}
