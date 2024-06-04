using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Service.Abstracts;
using School.ServiceHelper.Abstracts;

namespace SchoolProject.Controllers;
[Authorize]
public class MainController : Controller {
	private readonly ISchoolService _schoolService;
	private readonly IStudentService _studentService;
	private readonly ITeacherService _teacherService;
	private readonly IClassService _classService;

	public MainController(ISchoolService schoolService, IStudentService studentService, ITeacherService teacherService, IClassService classService) {
		_schoolService = schoolService;
		_studentService = studentService;
		_teacherService = teacherService;
		_classService = classService;
	}
	public IActionResult Index() {
		int schoolCount = _schoolService.List().Data.Count;
		int studentCount = _studentService.ListWithClassAndSchool().Data.Count;
		int teacherCount = _teacherService.List().Data.Count;
		int classCount = _classService.List().Data.Count;

		ViewBag.SchoolCount = schoolCount;
		ViewBag.StudentCount = studentCount;
		ViewBag.TeacherCount = teacherCount;
		ViewBag.ClassCount = classCount;
		return View();
	}
}
