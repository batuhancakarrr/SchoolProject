using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;
using SchoolProject.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SchoolProject.Controllers;
[Authorize]
public class ClassController : Controller {
	private readonly IClassService _classService;
	private readonly IClassTeacherService _classTeacherService;
	private readonly ITeacherService _teacherService;

	public ClassController(IClassService classService, IClassTeacherService classTeacherService, ITeacherService teacherService) {
		_classService = classService;
		_classTeacherService = classTeacherService;
		_teacherService = teacherService;
	}

	[Route("Classes")]
	public IActionResult List() {
		Result<List<ClassDTO>> result = _classService.ListWithSchool();
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return View(result.Data);
	}
	[HttpGet]
	public IActionResult ListJson() {
		Result<List<ClassDTO>> result = _classService.ListWithSchool();
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		var data = result.Data.Select(s => new { id = s.Id, degree = s.Degree, name = s.Name }).ToList();
		return Json(new { success = true, data });
	}
	[Route("Classes/GetClassStudentCounts"), HttpPost]
	public IActionResult GetClassStudentCounts() {
		Result<List<ClassDTO>> classResult = _classService.ListWithSchool();
		if (!classResult.Success) {
			return Json(new { success = false, message = "Sınıflar bulunamadı." });
		}

		var classStudentCounts = classResult.Data.Select(c => new {
			ClassName = $"{c.Degree}/{c.Name}",
			StudentCount = c.Students.Count
		}).ToList();

		return Json(new { success = true, data = classStudentCounts });
	}



	[Route("Classes/Details/{id}")]
	public IActionResult Details(int id) {
		ClassDetailsViewModel model = new();

		Result<List<TeacherDTO>> teacherResult = _teacherService.List();
		if (!teacherResult.Success) {
			TempData["Failed"] = "BAŞARISIZ.";
			return View(model);
		}

		Result<ClassDTO> classResult = _classService.GetById(id, true);
		if (!classResult.Success) {
			TempData["Failed"] = "BAŞARISIZ.";
			return View(model);
		}

		List<int> classTeachers = classResult.Data.ClassTeachers.Select(ct => ct.TeacherId).ToList();
		List<TeacherDTO> availableTeachers = teacherResult.Data.Where(t => !classTeachers.Contains(t.Id)).ToList();

		model.Teachers = availableTeachers;
		model.Class = classResult.Data;

		return View(model);
	}

	[Route("Classes/Edit/{id}")]
	public IActionResult Edit(int id) {
		Result<ClassDTO> result = _classService.GetById(id);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";

		JsonSerializerOptions options = new() {
			ReferenceHandler = ReferenceHandler.Preserve,
			WriteIndented = true
		};

		return new JsonResult(result.Data, options);
	}

	[Route("Classes/Add"), HttpPost]
	public IActionResult Add(ClassDTO classes) {
		Result<bool> result = _classService.Insert(classes);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		else TempData["Success"] = "Başarılı.";
		return RedirectToAction(nameof(List));
	}

	[Route("Classes/Update/{id}"), HttpPost]
	public IActionResult Update(int id, int degree, string name) {
		Result<ClassDTO> result = _classService.GetById(id, true);
		if (!result.Success) {
			TempData["Failed"] = "BAŞARISIZ.";
			return RedirectToAction(nameof(List));
		}

		ClassDTO existingClass = result.Data;
		if (existingClass == null) {
			TempData["Failed"] = "Sınıf bulunamadı.";
			return RedirectToAction(nameof(List));
		}

		existingClass.Degree = degree;
		existingClass.Name = name;

		Result<bool> updateResult = _classService.Update(existingClass);
		if (!updateResult.Success) {
			TempData["Failed"] = "BAŞARISIZ.";
		}

		return RedirectToAction(nameof(List));
	}

	[HttpDelete]
	[Route("Classes/Delete/{id}")]
	public IActionResult Delete(int id) {
		Result<ClassDTO> result = _classService.GetById(id);

		Result<bool> Result = _classService.Delete(result.Data.Id);
		if (!Result.Success) TempData["Failed"] = "BAŞARISIZ.";
		else TempData["Success"] = "Başarılı.";
		return RedirectToAction(nameof(List));
	}
	[Route("Classes/AddTeacherToClass")]
	[HttpPost]
	public IActionResult AddTeacherToClass(int classId, int[] States) {
		Result<List<ClassTeacherDTO>> result = _classTeacherService.AddTeacherToClass(classId, States);
		if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
		return RedirectToAction("Details", new { id = classId });
	}
}


