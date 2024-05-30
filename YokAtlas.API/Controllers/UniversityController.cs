using Microsoft.AspNetCore.Mvc;

namespace YokAtlas.API.Controllers;
[Route("[controller]/[action]")]
[ApiController]
public class UniversityController : ControllerBase {
	[HttpGet]
	public IActionResult Get() {
		return Ok(1);
	}
}
