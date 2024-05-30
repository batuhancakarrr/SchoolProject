using Microsoft.EntityFrameworkCore;
using School.Data.Entities.Concrete.Schools;
using EntitySchool = School.Data.Entities.Concrete.Schools.School;


namespace School.Data.Context;

public class SchoolContext : DbContext {
	public DbSet<EntitySchool> Schools { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Class> Classes { get; set; }
	public DbSet<ClassTeacher> ClassTeachers { get; set; }
	public DbSet<Admin> Admins { get; set; }
	public DbSet<City> Cities { get; set; }
	public DbSet<District> Districts { get; set; }
	public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
}
