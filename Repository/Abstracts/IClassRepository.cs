using School.Data.Entities.Concrete.Schools;

namespace Repository.Abstracts;

public interface IClassRepository : IRepository<Class> {
	List<Class> ListWithSchool();
}