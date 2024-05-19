using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstracts;
using EntitySchool = School.Data.Entities.School;

namespace SchoolProject.Controllers;
[Authorize]
public class SchoolController : Controller {
	private readonly ISchoolRepository _schoolRepository;

	public SchoolController(ISchoolRepository schoolRepository) {
		_schoolRepository = schoolRepository;
	}

	[Route("Schools")]
	public IActionResult List() {
		var schoolList = _schoolRepository.List();
		return View(schoolList);
	}

	[Route("Schools/Details/{id}")]
	public IActionResult Details(int id) {
		var students = _schoolRepository.GetStudentsBySchoolId(id);
		return View(students);
	}

	[Route("Schools/Edit/{id}")]
	public IActionResult Edit(int id) {
		var school = _schoolRepository.GetById(id);
		return Json(school);
	}

	[Route("Schools/Add"), HttpPost]
	public IActionResult Add(EntitySchool school) {
		_schoolRepository.Insert(school);
		return RedirectToAction(nameof(List));
	}

	[HttpPost]
	[Route("Schools/Update/{id}")]
	public IActionResult Update(int id, string name, string address) {
		var school = _schoolRepository.GetById(id);
		school.Name = name;
		school.Address = address;
		_schoolRepository.Update(school);
		return Ok();
	}

	[HttpPost]
	[Route("Schools/Delete/{id}")]
	public IActionResult Delete(int id) {
		var school = _schoolRepository.GetById(id);
		_schoolRepository.Delete(school);
		return RedirectToAction(nameof(List));
	}
}
