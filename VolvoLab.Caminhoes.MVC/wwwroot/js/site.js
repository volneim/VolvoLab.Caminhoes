function atribuirIdCaminhao(Id) {

    $("#caminhaoViewModel_Id").attr("value", Id);

};

function editarCaminhao(Id) {

    
    $.ajax(
        {
            type: 'GET',
            url: '/Caminhao/Edit/' + Id,
            dataType: 'HTML',
            cache: true,
            async: true,
            success: function (data) {

                $('#formEdit').html(data);
                $('#edit').modal('show');

            },
            error: function (request, status, error) {
                console("erro:" + request.responseText);
            }

        });
}
