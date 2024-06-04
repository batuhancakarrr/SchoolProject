using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities.Concrete.University;
using School.Service.Result;
using SchoolProject.Configuration;

namespace SchoolProject.Controllers;
[Authorize]

public class UniversityController : Controller {
	public IActionResult Index() {
		return View();
	}

	[Route("University/GetUniversities"), HttpGet]
	public async Task<IActionResult> GetUniversities() {
		Result<IEnumerable<University>> universities = await HttpClientHelper.GetUniversities();
		return Json(universities.Data);
	}
	[Route("University/GetDepartments"), HttpGet]
	public async Task<IActionResult> GetDepartments() {
		Result<IEnumerable<Department>> departments = await HttpClientHelper.GetDepartments();
		return Json(departments.Data);
	}
	[Route("University/GetUniversityById")]
	[HttpGet]
	public async Task<IActionResult> GetUniversityById(int universityId) {
		Result<IEnumerable<Department>> result = await HttpClientHelper.GetDepartmentsByUniversityId(universityId);
		if (result.Success) {
			return View(result.Data);
		}
		else {
			return StatusCode(500, result.ErrorMessage);
		}
	}
	[Route("University/GetDepartmentById")]
	[HttpGet]
	public async Task<IActionResult> GetDepartmentById(int departmentId) {
		Result<IEnumerable<University>> result = await HttpClientHelper.GetUniversitiesByDepartmentId(departmentId);
		if (result.Success) {
			return View(result.Data);
		}
		else {
			return StatusCode(500, result.ErrorMessage);
		}
	}
}
