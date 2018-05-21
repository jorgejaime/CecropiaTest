var productList = (function () {


    $(document).ready(function () {
        $('#tableProduct').DataTable({
            "processing": false,
            "serverSide": false,
           
            "ajax": resolveUrl("~/Products/List"),
            "columns": [
                {
                    "orderable": false,
                    "data": "id",
                    "width": "10%",
                    "render": function (data, type, row, meta) {
                        
                        var html = "<div>";
                        html += "<a class='btn btn-default btn-sm' href='" + resolveUrl("~/Products/Edit/" + data) + "'><i class='fa fa-edit'></i></a>";
                        html += "<a class='btn btn-default btn-sm' href='#' onclick='productEdit.deleteProduct(" + data + ",\"" + row.sku + "\")'><i class='fa fa-trash'></i></a>";
                        html += "</div>";
                        return html;
                    }
                },
                {
                    "orderable": false,
                    "data": "image",
                    "render": function (data, type, row, meta) {

                        var html = "<div> ";
                        html += "<img  height='42' width='42' src='data: image/jpeg;base64," + data + "'/>";
                        html += "</div>";
                        return html;
                    }
                },
                { "data": "sku" },
                { "data": "description" },
                { "data": "quantityStock" },
                { "data": "finalPrice" },
                { "data": "regularPrice" }
            ],
            "order": [[1, 'asc']],
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });
    });


}());