using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;

namespace SchoolProject.Controllers {
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
			Result<bool> result = _teacherService.Insert(teacher);
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
			TeacherDTO teacher = new TeacherDTO {
				Id = id,
				Name = name,
				Branch = branch
			};
			Result<bool> result = _teacherService.Update(teacher);
			if (result.Success) {
				return Ok();
			}
			else {
				return BadRequest(result.Message);
			}
		}
	}
}
