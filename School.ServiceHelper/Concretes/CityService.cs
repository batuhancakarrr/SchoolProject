using School.Data.Entities.Concrete.Schools;
using School.Dto;
using School.Repository.Abstracts;
using School.ServiceHelper.Abstracts;

namespace School.ServiceHelper.Concretes;

public class CityService : Service<City, CityDTO>, ICityService {
	private readonly ICityRepository _cityRepository;

	public CityService(ICityRepository cityRepository) : base(cityRepository) {
		_cityRepository = cityRepository;
	}

}
