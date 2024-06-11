using School.Data.Entities.Abstract;

namespace School.Data.Entities.Concrete.University;
public class User : BaseEntity {
	public string UserName { get; set; }
	public string Password { get; set; }
}