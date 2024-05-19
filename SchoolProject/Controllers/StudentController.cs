using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Abstracts;
using School.Data.Entities;

namespace SchoolProject.Controllers {
	[Authorize]
	public class StudentController : Controller {
		private readonly IStudentRepository _studentRepository;

		public StudentController(IStudentRepository studentRepository) {
			_studentRepository = studentRepository;
		}

		[Route("Students")]
		public IActionResult List() {
			List<Student> studentList = _studentRepository.ListWithClassAndSchool();
			return View(studentList);
		}

		[Route("Students/Details/{id}")]
		public IActionResult Details(int id) {
			Student student = _studentRepository.GetByIdWithClassAndSchool(id);
			return View(student);
		}

		[Route("Students/Edit/{id}")]
		public IActionResult Edit(int id) {
			Student student = _studentRepository.GetById(id);
			return Json(student);
		}

		[Route("Students/Add"), HttpPost]
		public IActionResult Add(Student student) {
			var newStudent = new Student {
				Name = student.Name,
				ClassId = student.ClassId,
				Username = student.Name,
				Password = "123"
			};
			_studentRepository.Insert(newStudent);
			return RedirectToAction(nameof(List));
		}

		[Route("Students/Update/{id}"), HttpPost]
		public IActionResult Update(int id, string name, int classId) {
			Student student = _studentRepository.GetById(id);
			student.Name = name;
			student.ClassId = classId;

			_studentRepository.Update(student);
			return Ok();
		}
	}
}
