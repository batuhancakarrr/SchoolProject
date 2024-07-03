using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;
using SchoolProject.Configuration;
using SchoolProject.Models;
using System.Security.Claims;

namespace SchoolProject.Controllers;
public class LoginController : Controller {
	private readonly IStudentService _studentService;
	private readonly ITeacherService _teacherService;
	private readonly HttpClientHelper _httpClientHelper;
	private readonly YokAtlasModel _yokAtlasSettings;
	public LoginController(IStudentService studentService, ITeacherService teacherService, HttpClientHelper httpClientHelper, IOptions<YokAtlasModel> yokAtlasSettings) {
		_studentService = studentService;
		_teacherService = teacherService;
		_httpClientHelper = httpClientHelper;
		_yokAtlasSettings = yokAtlasSettings.Value;
	}
	public IActionResult Index() {
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Login(LoginModel login) {
		if (login.userType == "student") {
			Result<StudentDTO> result = await _studentService.Login(login.username, login.password);
			if (!result.Success) return View("Index");

		}
		else if (login.userType == "teacher") {
			Result<TeacherDTO> result = await _teacherService.Login(login.username, login.password);
			if (!result.Success) return View("Index");
		}
		else return View("Index");
		Result<TokenModel> tokenResponse = await _httpClientHelper.Login(_yokAtlasSettings.UserName, _yokAtlasSettings.Password); // appsettings
		if (!tokenResponse.Success) {
			TempData["Failed"] = "Token hatası: " + tokenResponse.ErrorMessage;
			return RedirectToAction("Index", "Login");
		}

		List<Claim> claims = [
			new(ClaimTypes.Name, login.username),
			new(ClaimTypes.Role, login.userType),
			new("Token", "Bearer " + tokenResponse.Data.Token),
		];
		ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		AuthenticationProperties authProperties = new();

		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

		return RedirectToAction("Index", "Main");
	}
	[HttpPost]
	public async Task<IActionResult> Logout() {
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("Index", "Login");
	}
}

