function openPopup(id) {
	// Seçilen sınıfın özelliklerini almak için AJAX isteği gönder
	$.ajax({
		url: '/Classes/Edit/' + id,
		type: 'GET',
		success: function (response) {
			// AJAX isteği başarılı olursa, sınıf özelliklerini popup formunda görüntüle
			$('#classId').val(response.id);
			$('#degree').val(response.degree);
			$('#className').val(response.name);
			$("#formPopUp").show().css("display", "flex");
			$('#overlay').show();
		},
		error: function (xhr, status, error) {
			console.error(xhr.responseText);
		}
	});

	// Kaydet butonuna tıklandığında yapılacak işlemler
	$('#kaydet').click(function () {
		// Form verilerini al
		var degree = $('#degree').val();
		var className = $('#className').val();

		// AJAX isteği göndererek verileri sunucuya gönder
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
	var classId = $(this).data('id'); // Tıklanan düzenleme ikonunun data-id'sini al
	openPopup(classId); // Popup formunu aç
});