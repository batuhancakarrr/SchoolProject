function openPopup(studentId) {
	// Seçilen sınıfın özelliklerini almak için AJAX isteği gönder
	$.ajax({
		url: '/Students/Edit/' + studentId,
		type: 'GET',
		success: function (response) {
			// AJAX isteği başarılı olursa, sınıf özelliklerini popup formunda görüntüle
			$('#studentId').val(response.studentId);
			$('#studentName').val(response.name);
			$('#classId').val(response.classId);
			$("#formPopUp").show().css("display", "flex");
			$('#overlay').show();
		},
		error: function (xhr) {
			console.error(xhr.responseText);
		}
	});

	// Kaydet butonuna tıklandığında yapılacak işlemler
	$('#kaydet').click(function () {
		// Form verilerini al
		var name = $('#studentName').val();
		var classId = $('#classId').val();

		// AJAX isteği göndererek verileri sunucuya gönder
		$.ajax({
			url: '/Students/Update/' + studentId,
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
				// Kaydetme işlemi başarısız olduysa hata mesajını konsolda gösterin
				console.error("Kaydetme işlemi başarısız oldu: " + error);
			}
		});
	});
}

function closePopup() {
	$("#formPopUp").css("display", "none");
	$('#overlay').css("display", "none");
}

// Sınıf düzenleme butonuna tıklandığında popup formunu aç
$('.edit').click(function () {
	var studentId = $(this).data('id'); // Tıklanan düzenleme ikonunun data-id'sini al
	openPopup(studentId); // Popup formunu aç
});