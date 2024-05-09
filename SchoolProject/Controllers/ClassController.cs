using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;
using SchoolProject.Models;

namespace SchoolProject.Controllers;
public class ClassController : Controller {
	SchoolContext context = new();

	[Route("Classes")]
	public IActionResult List() {
		List<Class> classList = context.Classes.Include(x => x.School).ToList();
		return View(classList);
	}
	[Route("Classes/Details/{id}")]
	public IActionResult Details(int id) {
		ClassDetailsViewModel model = new();
		List<Student> students = context.Students.Where(x => x.ClassId == id).ToList();
		model.Students = students;
		List<ClassTeacher> classTeacher = context.ClassTeachers.Include(x => x.Teacher).Where(x => x.ClassId == id).ToList();
		model.ClassTeachers = classTeacher;
		return View(model);
	}

	[Route("Classes/Edit/{id}")]
	public IActionResult Edit(int id) {
		var classes = context.Classes.FirstOrDefault(x => x.Id == id);
		return Json(classes);
	}

	[HttpPost]
	[Route("Classes/Update/{id}")]
	public IActionResult Update(int id, int degree, string name) {
		var classes = context.Classes.FirstOrDefault(c => c.Id == id);

		classes.Degree = degree;
		classes.Name = name;

		context.SaveChanges();

		return Ok();
	}

}
