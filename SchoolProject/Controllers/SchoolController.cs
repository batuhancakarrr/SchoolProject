using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;
using SchoolProject.Models;
using EntitySchool = School.Data.Entities.School;

namespace SchoolProject.Controllers;
public class SchoolController : Controller {
	SchoolContext context = new();
	ClassDetailsViewModel model = new();

	[Route("Schools")]
	public IActionResult List() {
		List<EntitySchool> schoolList = context.Schools.ToList();
		return View(schoolList);
	}

	[Route("Schools/Details/{id}")]
	public IActionResult Details(int id) {
		List<Student> students = context.Students.Where(s => s.Class.SchoolId == id).Include(x => x.Class).ToList();
		model.Students = students;

		return View(model);
	}
}