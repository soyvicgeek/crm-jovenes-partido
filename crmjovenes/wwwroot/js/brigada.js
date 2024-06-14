let datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tblDatos').DataTable({
        "ajax": {
            "url": "/admin/Brigada/ObtenerTodos"
        },
        "columns": [
            { "data": "descripcion" },
            { "data": "numeroPersonas" },
            { "data": "localidad" },
            { "data": "municipio" },
            { "data": "zona.nombre" },
            {
                "data": "fecha",
                "render": function (data, type, row) {
                    if (type === 'display' || type === 'filter') {
                        return formatDate(data);
                    }
                    return data;
                }
            },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    } else {
                        return "Inactivo";
                    }
                },
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/Brigada/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a onclick=Delete("/Admin/Brigada/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer;">
                                <i class="bi bi-trash3-fill"></i>
                            </a>
                        </div>
                    `;
                }
            }
        ],
        responsive: true,
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });
}

function Delete(url) {
    swal({
        title: "¿Estas seguro de eliminar la Brigada?",
        text: "¡Este registro no se podrá recuperar!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((borrar) => {
        if (borrar) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

function formatDate(dateString) {
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const date = new Date(dateString);
    return date.toLocaleDateString('es-ES', options);
}