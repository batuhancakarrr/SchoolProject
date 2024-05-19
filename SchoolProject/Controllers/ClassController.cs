using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstracts;
using School.Data.Entities;
using SchoolProject.Models;

namespace SchoolProject.Controllers;
[Authorize]
public class ClassController : Controller {
	private readonly IClassRepository _classRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly IClassTeacherRepository _classTeacherRepository;

	public ClassController(IClassRepository classRepository, IStudentRepository studentRepository, IClassTeacherRepository classTeacherRepository) {
		_classRepository = classRepository;
		_studentRepository = studentRepository;
		_classTeacherRepository = classTeacherRepository;
	}

	[Route("Classes")]
	public IActionResult List() {
		List<Class> classList = _classRepository.ListWithSchool();
		return View(classList);
	}

	[Route("Classes/Details/{id}")]
	public IActionResult Details(int id) {
		var model = new ClassDetailsViewModel();

		var students = _studentRepository.GetStudentsByClassId(id);
		model.Students = students;

		var classTeachers = _classTeacherRepository.GetClassTeachersByClassId(id);
		model.ClassTeachers = classTeachers;

		return View(model);
	}

	[Route("Classes/Edit/{id}")]
	public IActionResult Edit(int id) {
		var classes = _classRepository.GetById(id);
		return Json(classes);
	}

	[Route("Classes/Add"), HttpPost]
	public IActionResult Add(Class classes) {
		_classRepository.Insert(classes);
		return RedirectToAction(nameof(List));
	}


	[HttpPost]
	[Route("Classes/Update/{id}")]
	public IActionResult Update(int id, int Degree, string Name) {
		var classes = _classRepository.GetById(id);
		classes.Degree = Degree;
		classes.Name = Name;

		_classRepository.Update(classes);
		return RedirectToAction(nameof(List));
	}
}
