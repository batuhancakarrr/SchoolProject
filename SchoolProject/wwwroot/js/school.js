function openPopup(schoolId) {
	// Seçilen sınıfın özelliklerini almak için AJAX isteği gönder
	$.ajax({
		url: '/Schools/Edit/' + schoolId,
		type: 'GET',
		success: function (response) {
			// AJAX isteği başarılı olursa, sınıf özelliklerini popup formunda görüntüle
			$('#schoolId').val(response.schoolId);
			$('#schoolName').val(response.name);
			$('#address').val(response.address);
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
		var name = $('#schoolName').val();
		var address = $('#address').val();

		// AJAX isteği göndererek verileri sunucuya gönder
		$.ajax({
			url: '/Schools/Update/' + schoolId,
			type: 'POST',
			data: {
				Name: name,
				address: address
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
	var schoolId = $(this).data('id'); // Tıklanan düzenleme ikonunun data-id'sini al
	openPopup(schoolId); // Popup formunu aç
});