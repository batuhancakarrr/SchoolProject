namespace School.Dto;

public class ClassDTO : BaseDTO {
	public int Degree { get; set; }
	public string Name { get; set; }
	public int SchoolId { get; set; }
	public SchoolDTO School { get; set; }
	public List<StudentDTO> Students { get; set; }
	public List<ClassTeacherDTO> ClassTeachers { get; set; }

}
