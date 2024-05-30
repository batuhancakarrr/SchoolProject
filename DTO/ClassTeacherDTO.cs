namespace School.Dto;
public class ClassTeacherDTO {
	public int ClassId { get; set; }
	public ClassDTO Class { get; set; }
	public int TeacherId { get; set; }
	public TeacherDTO Teacher { get; set; }
}
