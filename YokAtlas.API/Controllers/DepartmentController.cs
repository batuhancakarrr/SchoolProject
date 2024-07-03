using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase {
	private readonly UniversityDbContext _context;
	private readonly IMemoryCache _memoryCache;
	public DepartmentsController(UniversityDbContext context, IMemoryCache memoryCache) {
		_context = context;
		_memoryCache = memoryCache;
	}
	[Authorize]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Department>>> GetDepartments() {
		try {
			if (!_memoryCache.TryGetValue("CachedDepartments", out List<Department> cachedDepartments)) {
				cachedDepartments = await _context.Departments.ToListAsync();
				_memoryCache.Set("CachedDepartments", cachedDepartments, TimeSpan.FromHours(24));
			}
			return Ok(cachedDepartments);
		}
		catch (Exception ex) {
			return StatusCode(500, "Internal server error occurred.");
		}
	}
	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<Department>> GetDepartment(int id) {
		Department department = await _context.Departments.FindAsync(id);

		if (department == null) {
			return NotFound();
		}
		return department;
	}
}