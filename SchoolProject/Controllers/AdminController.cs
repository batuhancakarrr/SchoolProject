using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.Service.Abstracts;
using School.Service.Result;
using System.Security.Claims;

namespace SchoolProject.Controllers;

public class AdminController : Controller {
	private readonly IAdminService _adminService;
	public AdminController(IAdminService adminService) {
		_adminService = adminService;
	}
	public IActionResult Index() {
		return View();
	}
	public async Task<IActionResult> Admin(string username, string password) {
		Result<AdminDTO> result = await _adminService.Login(username, password);
		if (!result.Success) {
			return View("Index");
		}

		List<Claim> claims = new List<Claim> {
		new(ClaimTypes.Name, username),
		new(ClaimTypes.Role, "admin")
	};
		ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		AuthenticationProperties authProperties = new AuthenticationProperties();

		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

		return RedirectToAction("Index", "Main");
	}

	[HttpPost]
	public async Task<IActionResult> Logout() {
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("Index", "Admin");
	}
}

