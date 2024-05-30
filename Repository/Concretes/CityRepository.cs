using Repository.Concretes;
using School.Data.Context;
using School.Data.Entities.Concrete.Schools;
using School.Repository.Abstracts;

namespace School.Repository.Concretes;
public class CityRepository : Repository<City>, ICityRepository {
	private readonly SchoolContext _context;

	public CityRepository(SchoolContext context) : base(context) {
		_context = context;
	}


}
