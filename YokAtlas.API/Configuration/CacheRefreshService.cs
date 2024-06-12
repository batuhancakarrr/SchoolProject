using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using School.Data.Context;
using School.Data.Entities.Concrete.University;

namespace YokAtlas.API.Configuration;
public class CacheRefreshService : BackgroundService {
	private readonly IMemoryCache _memoryCache;
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ILogger<CacheRefreshService> _logger;
	private readonly IServiceScopeFactory _scopeFactory;

	public CacheRefreshService(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory, ILogger<CacheRefreshService> logger, IServiceScopeFactory scopeFactory) {
		_memoryCache = memoryCache;
		_httpClientFactory = httpClientFactory;
		_logger = logger;
		_scopeFactory = scopeFactory;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		while (!stoppingToken.IsCancellationRequested) {
			await RefreshCache(stoppingToken);
			await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
		}
	}

	private async Task RefreshCache(CancellationToken stoppingToken) {
		using IServiceScope scope = _scopeFactory.CreateScope();
		UniversityDbContext context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();

		try {
			List<University> universities = await context.Universities.ToListAsync(stoppingToken);
			_memoryCache.Set("CachedUniversities", universities, TimeSpan.FromHours(24));

			List<Department> departments = await context.Departments.ToListAsync(stoppingToken);
			_memoryCache.Set("CachedDepartments", departments, TimeSpan.FromHours(24));
		}
		catch (Exception ex) {
			_logger.LogError(ex, "Error refreshing cache");
		}
	}
}
