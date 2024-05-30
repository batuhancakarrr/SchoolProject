using Microsoft.EntityFrameworkCore;
using Repository.Concretes;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;
using School.Repository.Abstracts;

namespace School.Repository.Concretes;
public class DistrictRepository : Repository<District>, IDistrictRepository {
	private readonly SchoolContext _context;
	public DistrictRepository(SchoolContext context) : base(context) {
		_context = context;
	}
	public List<District> ListWithCity(int cityId) {
		return _context.Districts
					   .Include(x => x.City)
					   .Where(c => c.CityId == cityId)
					   .ToList();
	}
}
