﻿$(function () {
	$("section > table > tbody > tr > td:last-of-type").prev().find('i').on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");
		$.ajax({
			url: '/Classes/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editclassId').val(response.Id);
				$('#editdegree').val(response.Degree);
				$('#editclassName').val(response.Name);
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
		var name = $('#editclassName').val();

		$.ajax({
			url: '/Classes/Update/' + id,
			type: 'POST',
			data: {
				Id: id,
				Degree: degree,
				Name: name,
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
	$.ajax({
		url: 'School/ListJson',
		type: 'GET',
		success: function (response) {
			if (response.success) {
				console.log(response.data);
				var schoolSelect = $('#schoolId');
				schoolSelect.empty();
				$.each(response.data, function (index, school) {
					console.log(school); 
					schoolSelect.append($('<option>', {
						value: school.id,
						text: school.name
					}));
				});
			} else {
				alert(response.message);
			}
		},
		error: function () {
			alert("Okulları yüklerken bir hata oluştu.");
		}
	});

	$("#new").on("click", function () {
		$("#addoverlay").fadeIn();
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
})
function closePopup() {
	$('#editoverlay').fadeOut();
	$('#addoverlay').fadeOut();
}