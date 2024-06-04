$(function () {
    loadUniversities('#university');
    loadDepartments('#department');

    $("#university").on("change", function () {
        var universityId = $(this).val();
        if (universityId) {
            $("#universityForm").submit();
        }
    });
    $("#department").on("change", function () {
        var departmentId = $(this).val();
        if (departmentId) {
            $("#departmentForm").submit();
        }
    });
    function loadUniversities(selector) {
        $.ajax({
            url: '/University/GetUniversities',
            type: 'GET',
            success: function (universities) {
                var universitySelect = $(selector);
                universitySelect.empty();
                universitySelect.append(new Option("Üniversite Seçin", ""));
                universities.forEach(function (university) {
                    universitySelect.append(new Option(university.name, university.id));
                });
            },
            error: function (error) {
                console.error("İşlem başarasız oldu: " + error);
                showNotification(false, "BAŞARISIZ");
            }
        });
    }
    function loadDepartments(selector) {
        $.ajax({
            url: '/University/GetDepartments',
            type: 'GET',
            success: function (departments) {
                var departmentSelect = $(selector);
                departmentSelect.empty();
                departmentSelect.append(new Option("Bölüm Seçin", ""));
                departments.forEach(function (department) {
                    departmentSelect.append(new Option(department.name, department.id));
                });
            },
            error: function (error) {
                console.error("İşlem başarasız oldu: " + error);
                showNotification(false, "BAŞARISIZ");
            }
        });
    }
});
