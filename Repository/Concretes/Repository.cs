using Microsoft.EntityFrameworkCore;
using Repository.Abstracts;
using School.Data.Context;

namespace Repository.Concretes {
	public class Repository<T> : IRepository<T> where T : class {
		private readonly SchoolContext _context;
		private readonly DbSet<T> _dbSet;

		public Repository(SchoolContext context) {
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public List<T> List() {
			return _dbSet.ToList();
		}

		public T GetById(int id) {
			return _dbSet.Find(id);
		}

		public void Insert(T entity) {
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity) {
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity) {
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}
	}
}
