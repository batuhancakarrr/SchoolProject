using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : ControllerBase {
	private readonly UniversityDbContext _context;

	public UniversitiesController(UniversityDbContext context) {
		_context = context;
	}

	[Authorize]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<University>>> GetUniversities() {
		return await _context.Universities.ToListAsync();
	}

	[Authorize]
	[HttpGet("{id}")]
	public async Task<ActionResult<University>> GetUniversity(int id) {
		University university = await _context.Universities.FindAsync(id);

		if (university == null) {
			return NotFound();
		}

		return university;
	}
}
