using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Data.Context;
public class SchoolContext : DbContext{
	public DbSet<Entities.School> Schools { get; set; }
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Class> Classes { get; set; }
	public DbSet<ClassTeacher> ClassTeachers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		optionsBuilder.UseSqlServer("Data Source=DESKTOP-05G29TQ;Initial Catalog=SchoolDb;Trusted_Connection=true;TrustServerCertificate=true");
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<ClassTeacher>().HasNoKey();
	}
}
