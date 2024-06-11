using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase {
	private readonly UniversityDbContext _context;

	public DepartmentsController(UniversityDbContext context) {
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Department>>> GetDepartments() {
		return await _context.Departments.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Department>> GetDepartment(int id) {
		Department department = await _context.Departments.FindAsync(id);

		if (department == null) {
			return NotFound();
		}
		return department;
	}
}
