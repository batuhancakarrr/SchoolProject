using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Data.Entities.Concrete.University;
using School.ServiceHelper.Result;
using SchoolProject.Configuration;
using SchoolProject.Models;

namespace SchoolProject.Controllers;
[Authorize]

public class UniversityController : Controller {
	private readonly HttpClientHelper _httpClientHelper;

	public UniversityController(HttpClientHelper httpClientHelper) => _httpClientHelper = httpClientHelper;

	public async Task<IActionResult> Index() {
		Result<IEnumerable<University>> universitiesResult = await _httpClientHelper.GetUniversities<IEnumerable<University>>();
		Result<IEnumerable<Department>> departmentsResult = await _httpClientHelper.GetDepartments<IEnumerable<Department>>();

		if (universitiesResult.Success && departmentsResult.Success) {
			UniversityDepartmentViewModel viewModel = new() {
				Universities = universitiesResult.Data,
				Departments = departmentsResult.Data
			};
			return View(viewModel);
		}
		else {
			return StatusCode(500, "Veriler yüklenirken bir hata oluştu.");
		}
	}

	//[Route("University/GetUniversities"), HttpGet]
	//public async Task<IActionResult> GetUniversities() {
	//	//Result<IEnumerable<University>> universities = await _httpClientHelper.GetUniversities<IEnumerable<University>>();
	//	//return Json(universities.Data);
	//}
	//[Route("University/GetDepartments"), HttpGet]
	//public async Task<IActionResult> GetDepartments() {
	//	Result<IEnumerable<Department>> departments = await _httpClientHelper.GetDepartments<IEnumerable<Department>>();
	//	return Json(departments.Data);
	//}
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


