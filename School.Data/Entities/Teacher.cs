using School.Data.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities;
public class Teacher : BaseEntity {
    [MaxLength(50), Required]
    public string Name { get; set; }
    [MaxLength(50), Required]
    public string Branch { get; set; }
}
