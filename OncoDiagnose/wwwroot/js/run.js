var dataTable;
var controllerName = "Runs";

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `/Admin/${controllerName}/GetAll`
        },
        "columns": [
            { "data": "id" },
            { "data": "status" },
            { "data": "finishDate" },
            { "data": "test.id" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/${controllerName}/Upsert/${data}" class="btn btn-success text-white" style="cursor: pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a onclick=Delete("/Admin/${controllerName}/Delete/${data}") class="btn btn-danger text-white" style="cursor: pointer">
                                    <i class="fas fa-trash-alt"></i>
                                </a>
                            </div>
                            `;
                }
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Bạn chắc chắn muốn xoá?",
        text: "Bạn sẽ không thể khôi phục lại sau khi đã xoá!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}