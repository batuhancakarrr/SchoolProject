using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using System.Security.Claims;

namespace SchoolProject.Controllers;
public class AdminController : Controller {
	private readonly SchoolContext _context;
	public AdminController(SchoolContext context) {
		_context = context;
	}
	public IActionResult Index() {
		return View();
	}
	public async Task<IActionResult> Admin(string Username, string Password) {
		var admin = await _context.Admins.SingleOrDefaultAsync(s => s.Username == Username && s.Password == Password);

		var claims = new List<Claim> {
			new(ClaimTypes.Name, Username),
			new(ClaimTypes.Role, "admin")
		};
		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var authProperties = new AuthenticationProperties();

		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

		return RedirectToAction("Index", "Main");
	}
	[HttpPost]
	public async Task<IActionResult> Logout() {
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("Index", "Admin");
	}
}

