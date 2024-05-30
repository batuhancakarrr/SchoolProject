$(function () {
	$("section > table > tbody > tr > td:last-of-type").prev().find('i').on("click", function () {
		$("#editoverlay").fadeIn();
		const id = $(this).parent().find('.edit').attr("data-id");

		$.ajax({
			url: '/Schools/Edit/' + id,
			type: 'GET',
			success: function (response) {
				$('#editschoolId').val(response.id);
				$('#editname').val(response.name);
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
		var district = $('#editDistrict').val();

		$.ajax({
			url: '/Schools/Update/' + id,
			type: 'POST',
			data: {
				Name: name,
				DistrictId: district
			},
			success: function (response) {
				console.log("Veriler başarıyla kaydedildi.");
				location.reload();
			},
			error: function (error) {
				console.error("Kaydetme işlemi başarısız oldu: " + error);
				showNotification(false, "BAŞARISIZ");
			}
		});

	});

	$("#new").on("click", function () {
		$("#addoverlay").fadeIn();
	});
})
$(function () {
	function loadCities(selector) {
		$.ajax({
			url: '/Schools/GetCities',
			type: 'GET',
			success: function (cities) {
				var citySelect = $(selector);
				citySelect.empty();
				citySelect.append(new Option("Şehir Seçin", ""));
				cities.forEach(function (city) {
					citySelect.append(new Option(city.name, city.id));
				});
			},
			error: function (error) {
				console.error("Kaydetme işlemi başarısız oldu: " + error);
				showNotification(false, "BAŞARISIZ");
			}
		});
	}

	function loadDistricts(citySelect, districtSelect) {
		var cityId = citySelect.val();
		districtSelect.empty();
		districtSelect.append(new Option("İlçe seçin", ""));

		if (cityId) {
			$.ajax({
				url: '/Schools/GetDistricts/' + cityId,
				type: 'GET',
				success: function (districts) {
					districts.forEach(function (district) {
						districtSelect.append(new Option(district.name, district.id));
					});
				},
				error: function (error) {
					console.error("Kaydetme işlemi başarısız oldu: " + error);
					showNotification(false, "BAŞARISIZ");
				}
			});
		}
	}

	loadCities('#addformPopUp #city');
	loadCities('#editformPopUp #editCity');

	$('#addformPopUp #city').on('change', function () {
		loadDistricts($(this), $('#addformPopUp #district'));
	});

	$('#editformPopUp #editCity').on('change', function () {
		loadDistricts($(this), $('#editformPopUp #editDistrict'));
	});
});

function closePopup() {
	$('#editoverlay').css("display", "none");
	$('#addoverlay').css("display", "none");
}



