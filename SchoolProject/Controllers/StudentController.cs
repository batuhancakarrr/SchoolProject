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
	[Route("Students/Edit/{id}")]
	public IActionResult Edit(int id) {
		Student student = context.Students.FirstOrDefault(x => x.Id == id);
		return Json(student);
	}
	[HttpPost]
	[Route("Students/Update/{id}")]
	public IActionResult Update(int id, string name, int classId) {
		Student student = context.Students.FirstOrDefault(c => c.Id == id);
		Class classes = context.Classes.FirstOrDefault(c => c.Id == classId);

		try {
			if (classes != null) {
				student.Name = name;
				student.ClassId = classes.Id;
				context.SaveChanges();
			}
		}
		catch {
			return BadRequest("Sınıf bulunamadı.");
		}
		return Ok();
	}
}
