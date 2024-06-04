using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;

namespace SchoolProject.Controllers;
[Authorize]
public class StudentController : Controller {
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService) {
        _studentService = studentService;
    }

    [Route("Students")]
    public IActionResult List() {
        Result<List<StudentDTO>> result = _studentService.ListWithClassAndSchool();
        if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
        return View(result.Data);
    }

    [Route("Students/Details/{id}")]
    public IActionResult Details(int id) {
        Result<StudentDTO> result = _studentService.GetByIdWithClassAndSchool(id);
        if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
        return View(result.Data);
    }

    [Route("Students/Edit/{id}")]
    public IActionResult Edit(int id) {
        Result<StudentDTO> result = _studentService.GetByIdWithClassAndSchool(id);
        if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
        return Json(result.Data);
    }

    [Route("Students/Add"), HttpPost]
    public IActionResult Add(StudentDTO student) {
        Result<bool> result = _studentService.Add(student);
        if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
        else TempData["Success"] = "Başarılı.";
        return RedirectToAction(nameof(List));
    }

    [Route("Students/Update/{id}"), HttpPost]
    public IActionResult Update(int id, string name, int classId) {
        Result<bool> result = _studentService.Update(id, name, classId);
        if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
        return RedirectToAction(nameof(List));
    }
    [HttpDelete]
    [Route("Students/Delete/{id}")]
    public IActionResult Delete(int id) {
        Result<StudentDTO> result = _studentService.GetById(id);

        Result<bool> Result = _studentService.Delete(result.Data.Id);
        if (!Result.Success) TempData["Failed"] = "BAŞARISIZ.";
        else TempData["Success"] = "Başarılı.";
        return RedirectToAction(nameof(List));
    }
}
