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
	private readonly ILogger<UniversitiesController> _logger;
	public UniversitiesController(UniversityDbContext context, IMemoryCache memoryCache, ILogger<UniversitiesController> logger) {
		_context = context;
		_memoryCache = memoryCache;
		_logger = logger;
	}
	[Authorize]
	[HttpGet]
	public async Task<ActionResult<IEnumerable<University>>> GetUniversities() {
		if (!_memoryCache.TryGetValue("CachedUniversities", out List<University> cachedUniversities)) {
			_logger.LogInformation("Cache miss - fetching data from database.");
			cachedUniversities = await _context.Universities.ToListAsync();
			_memoryCache.Set("CachedUniversities", cachedUniversities, TimeSpan.FromHours(24));
		}
		else {
			_logger.LogInformation("Cache hit - fetching data from cache.");
		}
		return Ok(cachedUniversities);
	}
	// TODO: Try Catch hata yakalama
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