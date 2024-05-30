namespace School.Dto;
public class StudentDTO : BaseDTO {
	public string Name { get; set; }
	public int ClassId { get; set; }
	public ClassDTO Class { get; set; }
	public string Username { get; set; }
}