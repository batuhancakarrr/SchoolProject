$(function () {
	$('#addTeacherButton').on('click', function () {
		$('#addTeacherOverlay').fadeIn();
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