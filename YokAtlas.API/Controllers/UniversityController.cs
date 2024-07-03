using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UniversitiesController : ControllerBase {
	private readonly UniversityDbContext _context;
	private readonly IMemoryCache _memoryCache;
	public UniversitiesController(UniversityDbContext context, IMemoryCache memoryCache) {
		_context = context;
		_memoryCache = memoryCache;
	}
	[Authorize]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<University>>> GetUniversities() {
		try {
			if (!_memoryCache.TryGetValue("CachedUniversities", out List<University> cachedUniversities)) {
				cachedUniversities = await _context.Universities.ToListAsync();
				_memoryCache.Set("CachedUniversities", cachedUniversities, TimeSpan.FromHours(24));
			}
			return Ok(cachedUniversities);
		}
		catch (Exception ex) {
			return StatusCode(500, ex.Message);
		}
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