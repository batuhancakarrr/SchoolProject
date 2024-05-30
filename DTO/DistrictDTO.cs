namespace School.Dto;
public class DistrictDTO : BaseDTO {
	public string name { get; set; }
	public int CityId { get; set; }
	public CityDTO City { get; set; }
}

