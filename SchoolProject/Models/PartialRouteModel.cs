namespace SchoolProject.Models;

public class PartialRouteModel {
	public PartialRouteModel(string text) {
		Text = text;
		CurrenPage = true;
	}
	public PartialRouteModel(string text, string url) {
		Text = text;
		Url = url;
		CurrenPage = false;
	}
	public string Text { get; set; }
	public string Url { get; set; }
	public bool CurrenPage { get; set; }
}