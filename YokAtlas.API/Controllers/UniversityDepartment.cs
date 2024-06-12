using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversityDepartmentsController : ControllerBase {
	private readonly UniversityDbContext _context;

	public UniversityDepartmentsController(UniversityDbContext context) {
		_context = context;
	}
	[Authorize]
	[HttpGet("universities/{universityId}")]

	public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsForUniversity(int universityId) {
		List<Department> departments = await _context.UniversityDepartments
										 .Where(ud => ud.UniversityId == universityId)
										 .Select(ud => ud.Department)
										 .OrderBy(d => d.Name)
										 .ToListAsync();

		if (departments == null || !departments.Any()) {
			return NotFound();
		}

		return departments;
	}
	[Authorize]
	[HttpGet("departments/{departmentId}")]

	public async Task<ActionResult<IEnumerable<University>>> GetUniversitiesForDepartment(int departmentId) {
		List<University> universities = await _context.UniversityDepartments
										 .Where(ud => ud.DepartmentId == departmentId)
										 .Select(ud => ud.University)
										 .OrderBy(d => d.Name)
										 .ToListAsync();

		if (universities == null || !universities.Any()) {
			return NotFound();
		}

		return universities;
	}
}
