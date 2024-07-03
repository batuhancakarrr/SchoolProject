$(function () {
	$("#university").on("change", function () {
		var universityId = $(this).val();
		if (universityId) {
			$("#universityForm").submit();
			$('#university').val('');
		}
	});
	$("#department").on("change", function () {
		var departmentId = $(this).val();
		if (departmentId) {
			$("#departmentForm").submit();
			$('#department').val('');
		}
	});
});
