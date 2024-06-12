using Newtonsoft.Json;
using School.ServiceHelper.Result;
using SchoolProject.Models;
using System.Text;

namespace SchoolProject.Configuration;
public class HttpClientHelper {
	private readonly IHttpContextAccessor _httpContextAccessor;
	private readonly HttpClient HttpClient;
	public HttpClientHelper(IHttpContextAccessor httpContextAccessor) {
		_httpContextAccessor = httpContextAccessor;
		HttpClient = new() {
			BaseAddress = new("https://localhost:44310/"),
			DefaultRequestHeaders = {
				{ "Accept", "*/*" },
			}
		};
		if (_httpContextAccessor.HttpContext.User.Claims.Any(x => x.Type == "Token")) {
			HttpClient.DefaultRequestHeaders.Add("Authorization", _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "Token").Value);
		}
	}
	public async Task<Result<T>> GetUniversities<T>() {
		return await GetMethod<T>("/api/Universities");
	}
	public async Task<Result<T>> GetDepartments<T>() {
		return await GetMethod<T>("/api/Departments");
	}
	public async Task<Result<T>> GetDepartmentsByUniversityId<T>(int universityId) {
		string url = $"/api/UniversityDepartments/universities/{universityId}";
		return await GetMethod<T>(url);
	}
	public async Task<Result<T>> GetUniversitiesByDepartmentId<T>(int departmentId) {
		string url = $"/api/UniversityDepartments/departments/{departmentId}";
		return await GetMethod<T>(url);
	}
	public async Task<Result<TokenModel>> Login(string username, string password) {
		object loginModel = new {
			username = username,
			password = password
		};
		return await PostMethod<TokenModel>("/api/Auth/login", loginModel);
	}

	private async Task<Result<T>> GetMethod<T>(string url) {
		Result<T> result = new();
		try {
			using HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<T>(responseMessageContent);
			}
			else {
				result.ErrorMessage = "İstek sırasında hata oluştu";
				result.Success = false;
			}
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
	private async Task<Result<T>> PostMethod<T>(string url, object model) {
		Result<T> result = new();
		try {
			string json = JsonConvert.SerializeObject(model);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

			using HttpResponseMessage responseMessage = await HttpClient.PostAsync(url, content);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<T>(responseMessageContent);
			}
			else {
				result.ErrorMessage = "İstek sırasında hata oluştu";
				result.Success = false;
			}
		}
		catch (Exception ex) {
			result.Success = false;
			result.ErrorMessage = ex.Message;
		}
		return result;
	}
}

/*
 Claims erişmek için
 _httpContextAccessor.HttpContext?.User 
.net core'da bir class'a nasıl _httpContextAccessor'u dependency injection ile eklerim
*/