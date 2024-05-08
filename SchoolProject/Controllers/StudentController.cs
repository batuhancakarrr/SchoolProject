using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;

namespace SchoolProject.Controllers;
public class StudentController : Controller {
	[Route("Students")]
	public IActionResult List() {
		SchoolContext context = new();
		List<Student> studentList = context.Students.Include(x => x.Class).ThenInclude(x => x.School).ToList();
		return View(studentList);
	}
}
