var productEdit = (function () {



    var deleteProduct = function (id, name) {

        var message = "Delete product?";
        if (name != undefined) {
            message = "Delete product " + name + "?";
        }

        $('#confirmDeleteDialog').modal('show');

        $('#confirmDelete').on('click', function (result) {

            if (result) {
                var ajaxMethodUrl = resolveUrl("~/Products/Delete");

                if (id == undefined || id == null) {
                    id = $("#productId").val();
                }
                $.ajax({
                    async: true,
                    cache: false,
                    type: "Post",
                    url: ajaxMethodUrl,
                    data: {
                        id: id,
                        __RequestVerificationToken: $("form").find("input[name='__RequestVerificationToken']").val()
                    }
                }).done(function (resultData) {

                    $('#confirmDeleteDialog').modal('hide');

                    if (resultData.isValid) {

                        if (id == undefined || id == null) {
                            window.location = resolveUrl("~/Product");
                        } else {
                            var table = $("#tableProduct").DataTable();
                            table.search();
                            table.ajax.reload();
                        }

                    } else {

                        $("#pTextError").html(resultData.errorMessage);
                        $('#erroDialog').modal('show');
                    }


                }).fail(function (resultData) {

                    $("#pTextError").html("Errror deleting product.");
                    $('#erroDialog').modal('show');

                });


            }
        }

        );
    }


    $(document).ready(function () {

        $("#btnDelete").click(function () {

            deleteProduct();


        });

    });

    return {
        deleteProduct: deleteProduct
    }


}());