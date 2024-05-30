$(function () {
    const userImage = $("#userImage");
    const dropdownMenu = $("#dropdownMenu");

    userImage.on("click", function () {
        setTimeout(function () {
            dropdownMenu.toggleClass("show");
        }, 100);
    });

    $(document).on("click", function (event) {
        if (!userImage.is(event.target) && !dropdownMenu.is(event.target) && dropdownMenu.has(event.target).length === 0) {
            dropdownMenu.removeClass("show");
        }
    });

    $('#table').DataTable({
        dom: '<"top"lfB>rt<"bottom"ip><"clear">',
        language: {
            url: "//cdn.datatables.net/plug-ins/1.10.25/i18n/Turkish.json"
        },
        columnDefs: [
            { "orderable": false, "targets": -1 },
            { "orderable": false, "targets": -2 },
            { "orderable": false, "targets": -3 }
        ],
        buttons: [
            {
                extend: 'pdf',
                exportOptions: {
                    columns: ':visible:not(.bilgi, .duzenle, .sil)'
                },
                text: '<img src="/images/pdf.png" alt="Print" title="PDF" />',
            },
            {
                extend: 'csv',
                exportOptions: {
                    columns: ':visible:not(.bilgi, .duzenle, .sil)'
                },
                text: '<img src="/images/csv.png" alt="Print" title="CSV" />',
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: ':visible:not(.bilgi, .duzenle, .sil)'
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


function showNotification(success, message) {
	console.log("showNotification called with", success, message); 
	var notification = $('#JsNotification');

	if (!success) {
		notification.removeClass('success').addClass('error');
	}

	notification.text(message);

	notification.removeClass('hide').addClass('show');

	setTimeout(function () {
		notification.removeClass('show').addClass('hide');
	}, 3000);
}
function deleteItem(controllerName) {
	$("section > table > tbody > tr > td:last-of-type > i").on("click", function () {
		const id = $(this).parent().find('.delete').attr("data-id");
		if (confirm("Bu öğeyi silmek istediğinize emin misiniz?")) {
			$.ajax({
				url: '/' + controllerName + '/Delete/' + id,
				type: 'DELETE',
				success: function (response) {
					location.reload();
				},
				error: function (error) {
					alert("Silme işlemi başarısız oldu: " + error);
				}
			});
		}
	});
}

$(function () {
	var currentURL = window.location.pathname;
	var controllerName = currentURL.split('/')[1];
	deleteItem(controllerName);
});
