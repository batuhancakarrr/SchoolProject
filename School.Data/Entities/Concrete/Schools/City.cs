using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities.Concrete.Schools;
public class City : BaseEntity {

	[MaxLength(50)]
	public string name { get; set; }
}
