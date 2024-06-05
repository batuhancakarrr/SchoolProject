using School.Dto;
namespace SchoolProject.Models;

public class ClassDetailsViewModel {
    public int ClassId { get; set; }
    public ClassDTO Class { get; set; }
    public List<TeacherDTO> Teachers { get; set; }
}
