using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using School.Dto;
using School.ServiceHelper.Abstracts;
using School.ServiceHelper.Result;
using SchoolProject.Configuration;
using SchoolProject.Models;
using System.Security.Claims;

namespace SchoolProject.Controllers;

public class AdminController : Controller {
	private readonly IAdminService _adminService;
	private readonly HttpClientHelper _httpClientHelper;
	public AdminController(IAdminService adminService, HttpClientHelper httpClientHelper) {
		_adminService = adminService;
		_httpClientHelper = httpClientHelper;
	}
	public IActionResult Index() {
		return View();
	}
	public async Task<IActionResult> Admin(string username, string password) {
		Result<AdminDTO> result = await _adminService.Login(username, password);
		if (!result.Success) {
			return View("Index");
		}
		Result<TokenModel> tokenResponse = await _httpClientHelper.Login("SchoolProject", "sp123");
		if (!tokenResponse.Success) {
			TempData["Failed"] = "Token hatası: " + tokenResponse.ErrorMessage;
			return RedirectToAction("Index", "Login");
		}

		List<Claim> claims = [
		new(ClaimTypes.Name, username),
		new(ClaimTypes.Role, "admin"),
		new("Token", "Bearer " + tokenResponse.Data.Token)
		];
		ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		AuthenticationProperties authProperties = new();

		await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);

		return RedirectToAction("Index", "Main");
	}

	[HttpPost]
	public async Task<IActionResult> Logout() {
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		return RedirectToAction("Index", "Admin");
	}
}

