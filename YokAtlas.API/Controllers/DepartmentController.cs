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
	private readonly ILogger<DepartmentsController> _logger;
	public DepartmentsController(UniversityDbContext context, IMemoryCache memoryCache, ILogger<DepartmentsController> logger) {
		_context = context;
		_memoryCache = memoryCache;
		_logger = logger;
	}
	[Authorize]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Department>>> GetDepartments() {
		//_memoryCache.Remove("CachedDepartments");
		//_memoryCache.Remove("CachedUniversities");
		if (!_memoryCache.TryGetValue("CachedDepartments", out List<Department> cachedDepartments)) {
			_logger.LogInformation("Cache miss - fetching data from database.");
			cachedDepartments = await _context.Departments.ToListAsync();
			_memoryCache.Set("CachedDepartments", cachedDepartments, TimeSpan.FromHours(24));
		}
		else {
			_logger.LogInformation("Cache hit - fetching data from cache.");
		}
		return Ok(cachedDepartments);
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


