using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;

namespace SchoolProject.Controllers;
public class StudentController : Controller {
	SchoolContext context = new();
	[Route("Students")]
	public IActionResult List() {
		List<Student> studentList = context.Students.Include(x => x.Class).ThenInclude(x => x.School).ToList();
		return View(studentList);
	}
	[Route("Students/Details/{id}")]
	public IActionResult Details(int id) {
		Student student = context.Students.Include(x => x.Class).ThenInclude(x => x.School).FirstOrDefault(x => x.Id == id);
		return View(student);
	}
}
