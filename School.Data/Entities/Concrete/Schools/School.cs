using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities.Concrete.Schools;

public class School : BaseEntity {
	[MaxLength(50), Required]
	public string Name { get; set; }

	[ForeignKey("District"), Required]
	public int DistrictId { get; set; }
	public District District { get; set; }
}