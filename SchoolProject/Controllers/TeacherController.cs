using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entities;
using SchoolProject.Models;

namespace SchoolProject.Controllers;
public class TeacherController : Controller {
    SchoolContext context = new();
    [Route("Teachers")]
    public IActionResult List() {
        List<Teacher> teacherList = context.Teachers.ToList();
        return View(teacherList);
    }
    [Route("Teachers/Details/{id}")]
    public IActionResult Details(int id) {
        ClassTeacherViewModel model = new ClassTeacherViewModel();
        Teacher teacher = context.Teachers.SingleOrDefault(x => x.Id == id);
        model.Teacher = teacher;
        List<ClassTeacher> classTeacher = context.ClassTeachers.Include(x => x.Class).Where(x => x.TeacherId == id).ToList();
        model.ClassTeachers = classTeacher;

        return View(model);
    }

}
