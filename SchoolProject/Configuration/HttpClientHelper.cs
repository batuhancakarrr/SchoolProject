using Newtonsoft.Json;
using School.Data.Entities.Concrete.University;
using School.Service.Result;

namespace SchoolProject.Configuration;


public static class HttpClientHelper {
	static readonly HttpClient HttpClient = new() {
		BaseAddress = new("https://localhost:44359/"),
		DefaultRequestHeaders = {
			{ "Accept", "*/*" }
		}
	};
	public static async Task<Result<IEnumerable<University>>> GetUniversities() {
		return await GetUniversities<IEnumerable<University>>("/api/Universities");
	}
	public static async Task<Result<IEnumerable<Department>>> GetDepartments() {
		return await GetDepartments<IEnumerable<Department>>("/api/Departments");
	}
	public static async Task<Result<IEnumerable<Department>>> GetDepartmentsByUniversityId(int universityId) {
		string url = $"/api/UniversityDepartments/universities/{universityId}";
		return await GetDepartmentsByUniversityId<Department>(url);
	}
	public static async Task<Result<IEnumerable<University>>> GetUniversitiesByDepartmentId(int departmentId) {
		string url = $"/api/UniversityDepartments/departments/{departmentId}";
		return await GetUniversitiesByDepartmentId<University>(url);
	}

	private static async Task<Result<IEnumerable<University>>> GetUniversities<T>(string url) {
		Result<IEnumerable<University>> result = new();
		try {
			using HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<List<University>>(responseMessageContent);
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
	private static async Task<Result<IEnumerable<Department>>> GetDepartments<T>(string url) {
		Result<IEnumerable<Department>> result = new();
		try {
			using HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<List<Department>>(responseMessageContent);
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
	private static async Task<Result<IEnumerable<Department>>> GetDepartmentsByUniversityId<T>(string url) {
		Result<IEnumerable<Department>> result = new();
		try {
			using HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<IEnumerable<Department>>(responseMessageContent);
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
	private static async Task<Result<IEnumerable<University>>> GetUniversitiesByDepartmentId<T>(string url) {
		Result<IEnumerable<University>> result = new();
		try {
			using HttpResponseMessage responseMessage = await HttpClient.GetAsync(url);
			string responseMessageContent = await responseMessage.Content.ReadAsStringAsync();
			if (responseMessage.IsSuccessStatusCode) {
				result.Data = JsonConvert.DeserializeObject<IEnumerable<University>>(responseMessageContent);
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

