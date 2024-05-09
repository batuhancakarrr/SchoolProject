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
		return View(students);
	}
	[Route("Schools/Edit/{id}")]
	public IActionResult Edit(int id) {
		var school = context.Schools.FirstOrDefault(s => s.Id == id);
		return Json(school);
	}
	[HttpPost]
	[Route("Schools/Update/{id}")]
	public IActionResult Update(int id, string name, string address) {
		var school = context.Schools.FirstOrDefault(c => c.Id == id);

		school.Name = name;
		school.Address = address;

		context.SaveChanges();

		return Ok();
	}
}