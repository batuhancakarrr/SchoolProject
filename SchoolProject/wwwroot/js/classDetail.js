$(function () {
	$('#addTeacherButton').on('click', function () {
		$.ajax({
			url: '/Teachers/GetTeachers',
			type: 'GET',
			success: function (teachers) {
				var teacherSelect = $('.js-example-basic-multiple');
				teacherSelect.empty();
				teachers.forEach(function (teacher) {
					var optionText = teacher.name + " (" + teacher.branch + ")";
					teacherSelect.append(new Option(optionText, teacher.id));
				});
				$('#addTeacherOverlay').fadeIn();
			},
			error: function (error) {
				console.error("Öğretmenler yüklenirken hata oluştu: " + error);
			}
		});
	});

	$('#addTeacherForm').on('submit', function (e) {
		e.preventDefault();
		var teacherId = $('.js-example-basic-multiple').val();
		var classId = $('#classId').val();

		if (teacherId) {
			$.ajax({
				url: '/Classes/AddTeacherToClass',
				type: 'POST',
				data: {
					ClassId: classId,
					TeacherId: teacherId
				},
				success: function () {
					console.log("Eğitmen başarıyla eklendi.");
					closePopup();
					location.reload();
				},
				error: function (error) {
					console.error("Eğitmen eklenirken hata oluştu: " + error);
				}
			});
		} else {
			alert("Lütfen bir öğretmen seçin.");
		}
	});

	$('#closeAddTeacher').on('click', function () {
		closePopup();
	});

});
function closePopup() {
	$('#addTeacherOverlay').fadeOut();
}
$(function () {
	$('.js-example-basic-multiple').select2({
		width: '100%',
		placeholder: "Öğretmen Seçin",
		allowClear: true
	});
});