namespace School.Dto;
public class SchoolDTO : BaseDTO {
	public string Name { get; set; }
	public int DistrictId { get; set; }
	public DistrictDTO District { get; set; }

}
