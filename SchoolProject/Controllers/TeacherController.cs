using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstracts;
using School.Data.Entities;

namespace SchoolProject.Controllers {
	[Authorize]
	public class TeacherController : Controller {
		private readonly ITeacherRepository _teacherRepository;

		public TeacherController(ITeacherRepository teacherRepository) {
			_teacherRepository = teacherRepository;
		}

		[Route("Teachers")]
		public IActionResult List() {
			List<Teacher> teacherList = _teacherRepository.List();
			return View(teacherList);
		}

		[Route("Teachers/Details/{id}")]
		public IActionResult Details(int id) {
			List<ClassTeacher> classTeacher = _teacherRepository.GetClassesByTeacherId(id);
			return View(classTeacher);
		}

		[Route("Teachers/Add"), HttpPost]
		public IActionResult Add(Teacher teacher) {
			var newTeacher = new Teacher {
				Name = teacher.Name,
				Branch = teacher.Branch,
				Username = teacher.Name,
				Password = "123"
			};
			_teacherRepository.Insert(newTeacher);
			return RedirectToAction(nameof(List));
		}

		[Route("Teachers/Edit/{id}")]
		public IActionResult Edit(int id) {
			Teacher teacher = _teacherRepository.GetById(id);
			return Json(teacher);
		}

		[HttpPost]
		[Route("Teachers/Update/{id}")]
		public IActionResult Update(int id, string Name, string Branch) {
			Teacher teacher = _teacherRepository.GetById(id);
			if (teacher != null) {
				teacher.Name = Name;
				teacher.Branch = Branch;
				_teacherRepository.Update(teacher);
				return Ok();
			}
			return BadRequest("Öğretmen bulunamadı.");
		}
	}
}
