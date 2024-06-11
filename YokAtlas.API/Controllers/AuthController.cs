using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YokAtlas.API.Models;

namespace YokAtlas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
	private readonly IConfiguration _configuration;
	private readonly UniversityDbContext _context;
	public AuthController(UniversityDbContext context, IConfiguration configuration) {
		_configuration = configuration;
		_context = context;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] LoginModel model) {
		try {
			bool user = _context.Users.Any(x => x.UserName == model.username && x.Password == model.password);
			if (user) return Ok(new { Token = GenerateJwtToken(model.username) });
			else return Unauthorized("Yetkisiz Erişim");
		}
		catch (Exception ex) {
			return BadRequest(ex.Message);
		}
	}

	private string GenerateJwtToken(string name) {
		IConfigurationSection jwtSettings = _configuration.GetSection("Jwt");
		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
		SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

		Claim[] claims = [new Claim(ClaimTypes.Name, name)];

		JwtSecurityToken token = new(
			issuer: jwtSettings["Issuer"],
			audience: jwtSettings["Audience"],
			claims: claims,
			expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}