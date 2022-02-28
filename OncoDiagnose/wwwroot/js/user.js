var dataTable;
var controllerName = "User";

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `/Admin/${controllerName}/GetAll`
        },
        "columns": [
            { "data": "name" },
            { "data": "laboratory.name" },
            { "data": "email" },
            { "data": "phoneNumber" },
            { "data": "role" },
            {
                "data": {
                    id: "id",
                    lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        //user is currently locked
                        return `
                            <div class="text-center">

                                <a onclick=LockUnlock("${data.id}") class="btn btn-danger text-white" style="cursor: pointer">
                                    <i class="fas fa-lock-open"></i> Bỏ chặn
                                </a>
                            </div>
                            `;
                    } else {
                        return `
                            <div class="text-center">
                                <a onclick=LockUnlock("${data.id}") class="btn btn-success text-white" style="cursor: pointer">
                                    <i class="fas fa-lock"></i> Chặn
                                </a>
                            </div>
                            `;
                    }
                }
            }

        ]
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
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