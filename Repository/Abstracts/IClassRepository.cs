using School.Data.Entities;

namespace Repository.Abstracts {
	public interface IClassRepository : IRepository<Class> {
		List<Class> ListWithSchool();
	}
}