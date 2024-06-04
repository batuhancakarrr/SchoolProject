using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Abstracts;
using School.Data.Context;
using School.Data.Entities.Abstract;

namespace Repository.Concretes;
public class Repository<T> : IRepository<T> where T : class, IBaseEntity {
    private readonly SchoolContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(SchoolContext context) {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual List<T> List() {
        return _dbSet.AsNoTracking().ToList();
    }

    public virtual T GetById(int id, bool withTracking = false) {
        if (withTracking) return _dbSet.Find(id);
        else return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public virtual void Insert(T entity) {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    //public virtual void Update2(T entity) {
    //    _dbSet.Update(entity);
    //    _context.SaveChanges();
    //}
    public virtual void Update(T entity) {
        EntityEntry<T> entry = _context.Entry(entity);
        entry.State = EntityState.Modified;
        _context.SaveChanges();
    }


    public virtual void Delete(T entity) {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}
