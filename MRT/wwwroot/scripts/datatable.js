function toDatatable(id) {
    $(id).DataTable();
}

function destroyDatatable(id) {
    $(id).DataTable().destroy();
}

function setTimeInput(id, value) {
    $(id).val(value);
}