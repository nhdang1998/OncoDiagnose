var dataTable;
var controllerName = "Mutations";

$(document).ready(function () {
    loadDataTable();

});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `/Doctor/${controllerName}/GetAll`
        },
        "columns": [
            { "data": "cancerType.mainType"},
            { "data": "cancerType.tissue" },
            { "data": "cancerType.subtype" },
            { "data": "levelOfEvidence" },
            { "data": "evidenceType" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Doctor/${controllerName}/Details/${data}" class="btn btn-warning text-white" style="cursor: pointer">
                                    <i class="fas fa-info-circle"></i>
                                </a>
                            </div>
                            `;
                }
            }
        ]
    });
}
