$(function () {
	$("section > table > tbody > tr > td:last-of-type").prev().find('i').on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");

		$.ajax({
			url: '/Students/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editstudentId').val(response.id);
				$('#editname').val(response.name);
				$('#editclassId').val(response.classId);
				$('#editoverlay').show();
			},
			error: function (error) {
				console.error(error.responseText);
			}
		});
	});

	$('#kaydet').on("click", function () {

		var id = $('#editstudentId').val();
		var name = $('#editname').val();
		var classId = $('#editclassId').val();

		$.ajax({
			url: '/Students/Update/' + id,
			type: 'POST',
			data: {
				Name: name,
				ClassId: classId
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

