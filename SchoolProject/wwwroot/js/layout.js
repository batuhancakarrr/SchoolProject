document.addEventListener("DOMContentLoaded", function () {
    const userImage = document.getElementById("userImage");
    const dropdownMenu = document.getElementById("dropdownMenu");

    userImage.addEventListener("click", function () {
        setTimeout(function () {
            dropdownMenu.classList.toggle("show");
        }, 100); 
    });

    document.addEventListener("click", function (event) {
        if (!userImage.contains(event.target) && !dropdownMenu.contains(event.target)) {
            dropdownMenu.classList.remove("show");
        }
    });
	new DataTable('#table', {
		dom: '<"top"lfB>rt<"bottom"ip><"clear">',
		"language": {
			"url": "//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json"
		},
		"columnDefs": [
			{ "orderable": false, "targets": -1 },
			{ "orderable": false, "targets": -2 }
		],
		"buttons": [
			{
				extend: 'pdf',
				exportOptions: {
					columns: ':visible:not(.bilgi, .duzenle)'
				},
				text: '<img src="/images/pdf.png" alt="Print" title="PDF" />',
			},
			{
				extend: 'csv',
				exportOptions: {
					columns: ':visible:not(.bilgi, .duzenle)'
				},
				text: '<img src="/images/csv.png" alt="Print" title="CSV" />',
			},
			{
				extend: 'excel',
				exportOptions: {
					columns: ':visible:not(.bilgi, .duzenle)'
				},
				text: '<img src="/images/excel.png" alt="Print" title="EXCEL" />',
			}
		],
		layout: {
			topStart: {
				buttons: ['pdf', 'csv', 'excel']
			}
		}
	});
});

