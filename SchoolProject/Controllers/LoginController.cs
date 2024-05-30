using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Result;
using School.ServiceHelper.Abstracts;
using System.Security.Claims;

namespace SchoolProject.Controllers;
public class LoginController : Controller {
	private readonly IStudentService _studentService;
	private readonly ITeacherService _teacherService;
	public LoginController(IStudentService studentService, ITeacherService teacherService) {
		_studentService = studentService;
		_teacherService = teacherService;
	}
	public IActionResult Index() {
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Login(string username, string password, string userType) {
		if (userType == "student") {
			Result<StudentDTO> result = await _studentService.Login(username, password);
			if (!result.Success) {
				return View("Index");
			}
		}
		else if (userType == "teacher") {
			Result<TeacherDTO> result = await _teacherService.Login(username, password);
			if (!result.Success) {
				return View("Index");
			}
		}
		else {
			return View("Index");
		}

		List<Claim> claims = new List<Claim> {
			new(ClaimTypes.Name, username),
			new(ClaimTypes.Role, userType)
		};
		ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		AuthenticationProperties authProperties = new AuthenticationProperties();

		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

		return RedirectToAction("Index", "Main");
	}
	[HttpPost]
	public async Task<IActionResult> Logout() {
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("Index", "Login");
	}
}

