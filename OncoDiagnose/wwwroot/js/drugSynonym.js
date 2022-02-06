var dataTable;
var controllerName = "DrugSynonyms";

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": `/Admin/${controllerName}/GetAll`
        },
        "columns": [
            { "data": "drug.drugName", "width": "20%"},
            { "data": "synonym.synonymInformation", "width": "60%" },
            {
                "data": "drugId",
                "render": function (drugId) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/${controllerName}/Upsert/${drugId}" class="btn btn-success text-white" style="cursor: pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                            </div>
                            `;
                },
                "width": "20%"
            }
        ]
    });
}

