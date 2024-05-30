using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities.Concrete.Schools;
public class District : BaseEntity {

	[MaxLength(50)]
	public string name { get; set; }

	[ForeignKey("City")]
	public int CityId { get; set; }
	public City City { get; set; }
}
