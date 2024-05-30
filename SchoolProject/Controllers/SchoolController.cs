using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;
using School.ServiceHelper.Abstracts;


namespace SchoolProject.Controllers {
	[Authorize]
	public class SchoolController : Controller {
		private readonly ISchoolService _schoolService;
		private readonly ICityService _cityService;
		private readonly IDistrictService _districtService;

		public SchoolController(ISchoolService schoolService, ICityService cityService, IDistrictService districtService) {
			_schoolService = schoolService;
			_cityService = cityService;
			_districtService = districtService;
		}

		[Route("Schools")]
		public IActionResult List() {
			Result<List<SchoolDTO>> result = _schoolService.List();
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
			return View(result.Data);
		}

		[Route("Schools/Details/{id}")]
		public IActionResult Details(int id) {
			Result<List<StudentDTO>> result = _schoolService.GetStudentsBySchoolId(id);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
			return View(result.Data);
		}
		[Route("Schools/Edit/{id}")]
		public IActionResult Edit(int id) {
			Result<SchoolDTO> result = _schoolService.GetById(id);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";

			return Json(result.Data);
		}

		[Route("Schools/Add"), HttpPost]
		public IActionResult Add(SchoolDTO school) {
			Result<bool> result = _schoolService.Insert(school);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
			else TempData["Success"] = "Başarılı.";
			return RedirectToAction(nameof(List));
		}

		[HttpPost]
		[Route("Schools/Update/{id}")]
		public IActionResult Update(int id, string Name, int DistrictId) {
			Result<SchoolDTO> result = _schoolService.GetById(id);

			SchoolDTO school = result.Data;
			school.Name = Name;
			school.DistrictId = DistrictId;

			Result<bool> Result = _schoolService.Update(school);
			if (Result.Success) TempData["Success"] = "Başarılı.";
			return Ok();
		}

		[HttpDelete]
		[Route("Schools/Delete/{id}")]
		public IActionResult Delete(int id) {
			Result<SchoolDTO> result = _schoolService.GetById(id);

			Result<bool> Result = _schoolService.Delete(result.Data.Id);
			if (!Result.Success) TempData["Failed"] = "BAŞARISIZ.";
			else TempData["Success"] = "Başarılı.";
			return RedirectToAction(nameof(List));
		}

		[Route("Schools/GetCities")]
		public IActionResult GetCities() {
			Result<List<CityDTO>> result = _cityService.List();
			if (!result.Success) return BadRequest();

			return Json(result.Data);
		}
		[Route("Schools/GetDistricts/{id}")]
		public IActionResult GetDistricts(int id) {

			Result<List<DistrictDTO>> result = _districtService.ListWithCity(id);
			if (!result.Success) return BadRequest();

			return Json(result.Data);
		}
	}
}
