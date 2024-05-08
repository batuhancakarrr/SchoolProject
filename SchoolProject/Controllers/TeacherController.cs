using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;

namespace SchoolProject.Controllers;
public class TeacherController : Controller {
	SchoolContext context = new();
	[Route("Teachers")]
	public IActionResult List() {
		List<Teacher> teacherList = context.Teachers.ToList();
		return View(teacherList);
	}
	[Route("Teachers/Details/{id}")]
	public IActionResult Details(int id) {
		List<ClassTeacher> classTeacher = context.ClassTeachers
			.Include(x => x.Class)
			.Include(x => x.Teacher)
			.Where(x => x.TeacherId == id)
			.ToList();

		return View(classTeacher);
	}

}
