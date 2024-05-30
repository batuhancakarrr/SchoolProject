using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SchoolProject.Controllers {
	[Authorize]
	public class ClassController : Controller {
		private readonly IClassService _classService;

		public ClassController(IClassService classService) {
			_classService = classService;
		}

		[Route("Classes")]
		public IActionResult List() {
			Result<List<ClassDTO>> result = _classService.ListWithSchool();
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
			return View(result.Data);
		}

		[Route("Classes/Details/{id}")]
		public IActionResult Details(int id) {
			Result<ClassDTO> result = _classService.GetById(id, true);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";
			return View(result.Data);
		}

		[Route("Classes/Edit/{id}")]
		public IActionResult Edit(int id) {
			Result<ClassDTO> result = _classService.GetById(id);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";

			JsonSerializerOptions options = new JsonSerializerOptions {
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
			Result<ClassDTO> result = _classService.GetById(id);
			if (!result.Success) TempData["Failed"] = "BAŞARISIZ.";

			ClassDTO classes = result.Data;
			classes.Degree = degree;
			classes.Name = name;

			Result<bool> Result = _classService.Update(classes);
			if (!Result.Success) TempData["Failed"] = "BAŞARISIZ.";
			else TempData["Success"] = "Başarılı.";
			return BadRequest();
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

	}
}
