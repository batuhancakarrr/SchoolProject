$(function () {
	$("section > table > tbody > tr > td:last-of-type").prev().find('i').on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");

		$.ajax({
			url: '/Teachers/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editteacherId').val(response.id);
				$('#editname').val(response.name);
				$('#editbranch').val(response.branch);
				$('#editoverlay').show();
			},
			error: function (error) {
				console.error(error.responseText);
			}
		});
	});

	$('#kaydet').on("click", function () {

		var id = $('#editteacherId').val();
		var name = $('#editname').val();
		var branch = $('#editbranch').val();

		$.ajax({
			url: '/Teachers/Update/' + id,
			type: 'POST',
			data: {
				Name: name,
				Branch: branch
			},
			success: function () {
				console.log("Veriler başarıyla kaydedildi.");
				closePopup();
				location.reload();
			},
			error: function (error) {
				console.error("Kaydetme işlemi başarısız oldu: " + error);
			}
		});
	});
	$("#new").on("click", function () {
		$("#addoverlay").fadeIn();
	});
	$("#newbulk").on("click", function () {
		$("#bulkAddOverlay").fadeIn();
	});
	$("#editoverlay").on("click", function (e) {
		if (e.target.id === "editoverlay") {
			$("#editoverlay").fadeOut();
		}
	});
	$("#addoverlay").on("click", function (e) {
		if (e.target.id === "addoverlay") {
			$("#addoverlay").fadeOut();
		}
	});
	$("#bulkAddOverlay").on("click", function (e) {
		if (e.target.id === "bulkAddOverlay") {
			$("#bulkAddOverlay").fadeOut();
		}
	});
})
function closePopup() {
	$('#editoverlay').fadeOut();
	$('#addoverlay').fadeOut();
	$('#bulkAddOverlay').fadeOut();
}
$('#excelFile').on('change', function () {
	var label = $(this).next('label');
	if (this.files.length > 0) {
		label.text(this.files[0].name);
	} else {
		label.text('Dosya seçin veya sürükleyin');
	}
});
