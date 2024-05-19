namespace Repository.Abstracts {
	public interface IRepository<T> where T : class {
		List<T> List();
		T GetById(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
