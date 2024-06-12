using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;

namespace SchoolProject.Controllers;
[Authorize]
public class TeacherController : Controller {
	private readonly ITeacherService _teacherService;

	public TeacherController(ITeacherService teacherService) {
		_teacherService = teacherService;
	}

	[Route("Teachers")]
	public IActionResult List() {
		Result<List<TeacherDTO>> result = _teacherService.List();
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return View(result.Data);
	}

	[Route("Teachers/Details/{id}")]
	public IActionResult Details(int id) {
		Result<List<ClassTeacherDTO>> result = _teacherService.GetClassesByTeacherId(id);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return View(result.Data);
	}

	[Route("Teachers/Add"), HttpPost]
	public IActionResult Add(TeacherDTO teacher) {
		Result<bool> result = _teacherService.Add(teacher);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		else TempData["Success"] = "Başarılı.";
		return RedirectToAction(nameof(List));
	}

	[Route("Teachers/Edit/{id}")]
	public IActionResult Edit(int id) {
		Result<TeacherDTO> result = _teacherService.GetById(id);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return Json(result.Data);
	}

	[HttpPost]
	[Route("Teachers/Update/{id}")]
	public IActionResult Update(int id, string name, string branch) {
		Result<bool> result = _teacherService.Update(id, name, branch);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return RedirectToAction(nameof(List));
	}
	[HttpDelete]
	[Route("Teachers/Delete/{id}")]
	public IActionResult Delete(int id) {
		Result<TeacherDTO> result = _teacherService.GetById(id);

		Result<bool> Result = _teacherService.Delete(result.Data.Id);
		if (!Result.Success) TempData["Failed"] = "BAŞARISIZ.";
		else TempData["Success"] = "Başarılı.";
		return RedirectToAction(nameof(List));
	}
}
