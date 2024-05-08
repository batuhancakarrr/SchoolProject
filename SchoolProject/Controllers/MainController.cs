using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Controllers;
public class MainController : Controller {
	public IActionResult Index() {
		return View();
	}
}
