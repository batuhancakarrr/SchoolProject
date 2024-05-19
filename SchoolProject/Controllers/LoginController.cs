//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School.Data.Context;
//using System.Security.Claims;

//namespace SchoolProject.Controllers;
//public class LoginController : Controller {
//	SchoolContext context = new();
//	public IActionResult Index() {
//		return View();
//	}
//	[HttpPost]
//	public async Task<IActionResult> Login(string username, string password, string userType) {
//		if (userType == "student") {
//			var student = await context.Students.SingleOrDefaultAsync(s => s.Username == username && s.Password == password);
//			if (student == null) {
//				ModelState.AddModelError(string.Empty, "Öğrenci kullanıcı adı veya şifre yanlış");
//				return View("Index");
//			}
//		}
//		else if (userType == "teacher") {
//			var teacher = await context.Teachers.SingleOrDefaultAsync(t => t.Username == username && t.Password == password);
//			if (teacher == null) {
//				ModelState.AddModelError(string.Empty, "Öğretmen kullanıcı adı veya şifre yanlış");
//				return View("Index");
//			}
//		}
//		else {
//			ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı tipi");
//			return View("Index");
//		}

//		var claims = new List<Claim> {
//			new(ClaimTypes.Name, username),
//			new(ClaimTypes.Role, userType)
//		};
//		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//		var authProperties = new AuthenticationProperties();

//		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

//		return RedirectToAction("Index", "Main");
//	}
//	[HttpPost]
//	public async Task<IActionResult> Logout() {
//		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//		return RedirectToAction("Index", "Login");
//	}
//}

