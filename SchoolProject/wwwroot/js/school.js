$(function () {
	$("section > table > tbody > tr > td:last-of-type > i").on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");

		$.ajax({
			url: '/Schools/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editschoolId').val(response.id);
				$('#editname').val(response.name);
				$('#editaddress').val(response.address);
				$('#editoverlay').show();
			},
			error: function (error) {
				console.error(error.responseText);
			}
		});
	});

	$('#kaydet').on("click", function () {

		var id = $('#editschoolId').val();
		var name = $('#editname').val();
		var address = $('#editaddress').val();

		$.ajax({
			url: '/Schools/Update/' + id,
			type: 'POST',
			data: {
				name: name,
				address: address
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
