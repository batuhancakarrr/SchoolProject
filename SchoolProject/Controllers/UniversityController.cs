using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities.Concrete.University;
using School.ServiceHelper.Result;
using SchoolProject.Configuration;

namespace SchoolProject.Controllers;
[Authorize]

public class UniversityController : Controller {
	private readonly HttpClientHelper _httpClientHelper;

	public UniversityController(HttpClientHelper httpClientHelper) => _httpClientHelper = httpClientHelper;

	public IActionResult Index() {
		return View();
	}

	[Route("University/GetUniversities"), HttpGet]
	public async Task<IActionResult> GetUniversities() {
		Result<IEnumerable<University>> universities = await _httpClientHelper.GetUniversities<IEnumerable<University>>();
		return Json(universities.Data);
	}
	[Route("University/GetDepartments"), HttpGet]
	public async Task<IActionResult> GetDepartments() {
		Result<IEnumerable<Department>> departments = await _httpClientHelper.GetDepartments<IEnumerable<Department>>();
		return Json(departments.Data);
	}
	[Route("University/GetUniversityById")]
	[HttpGet]
	public async Task<IActionResult> GetUniversityById(int universityId) {
		Result<IEnumerable<Department>> result = await _httpClientHelper.GetDepartmentsByUniversityId<IEnumerable<Department>>(universityId);
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
		Result<IEnumerable<University>> result = await _httpClientHelper.GetUniversitiesByDepartmentId<IEnumerable<University>>(departmentId);
		if (result.Success) {
			return View(result.Data);
		}
		else {
			return StatusCode(500, result.ErrorMessage);
		}
	}
}


