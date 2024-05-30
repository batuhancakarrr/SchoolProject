using Repository.Abstracts;
using School.Data.Entities.Concrete.Schools;

namespace School.Repository.Abstracts;
public interface IDistrictRepository : IRepository<District> {
	List<District> ListWithCity(int id);
}
