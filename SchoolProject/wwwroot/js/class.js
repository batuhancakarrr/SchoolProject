$(function () {
	$("section > table > tbody > tr > td:last-of-type > i").on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");

		$.ajax({
			url: '/Classes/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editclassId').val(response.id);
				$('#editdegree').val(response.degree);
				$('#editclassName').val(response.name);
				$('#editoverlay').show();
			},
			error: function (error) {
				console.error(error.responseText);
			}
		});
	});

	$('#kaydet').on("click", function () {

		var id = $('#editclassId').val();
		var degree = $('#editdegree').val();
		var className = $('#editclassName').val();

		$.ajax({
			url: '/Classes/Update/' + id,
			type: 'POST',
			data: {
				degree: degree,
				name: className
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
})

function closePopup() {
	$('#editoverlay').css("display", "none");
	$('#addoverlay').css("display", "none");
}


