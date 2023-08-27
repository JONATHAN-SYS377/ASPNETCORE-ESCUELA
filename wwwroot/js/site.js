
//$("form").submit(function (event) {
//    //if (!$("input[name='Persona.tipoCedula']").is(":checked")) {
//    //    alert("Por favor, selecciona el tipo de cédula.");
//    //    event.preventDefault(); // Evita que el formulario se envíe
//    //}

//    if (!$("input[name='Sexo']").is(":checked")) {
//        alert("Por favor, selecciona el género.");
//        event.preventDefault(); // Evita que el formulario se envíe
//    }

//    //if (!$("input[name='TipoCliente']").is(":checked")) {
//    //    alert("Por favor, selecciona el tipo de cliente.");
//    //    event.preventDefault(); // Evita que el formulario se envíe
//    //}
//});


$(document).ready(function () {
    // Manejar el cambio de provincia
    $("#Provincia").change(function () {
        var selectedProvincia = $(this).val();
        if (selectedProvincia) {
            $.getJSON("/Personas/GetCantones", { provinciaId: selectedProvincia }, function (data) {
                $("#Canton").empty();
                $.each(data, function (index, item) {
                    $("#Canton").append("<option value='" + item.value + "'>" + item.text + "</option>");
                });
            });
        } else {
            $("#Canton").empty();
            $("#Distrito").empty();
            $("#Barrio").empty();
        }
    });

    // Manejar el cambio de cantón
    $("#Canton").change(function () {
        var selectedProvincia = $("#Provincia").val();
        var selectedCanton = $(this).val();
        if (selectedCanton) {
            $.getJSON("/Personas/GetDistritos", { provinciaId: selectedProvincia, cantonId: selectedCanton }, function (data) {
                $("#Distrito").empty();
                $.each(data, function (index, item) {
                    $("#Distrito").append("<option value='" + item.value + "'>" + item.text + "</option>");
                });
            });
        } else {
            $("#Distrito").empty();
            $("#Barrio").empty();
        }
    });

    $("#Distrito").change(function () {
        var selectedProvincia = $("#Provincia").val();
        var selectedCanton = $("#Canton").val();
        var selectedDistrito = $(this).val();
        if (selectedDistrito) {
            $.getJSON("/Personas/GetBarrios", { provinciaId: selectedProvincia, cantonId: selectedCanton, distritoId: selectedDistrito }, function (data) {
                $("#Barrio").empty();
                $.each(data, function (index, item) {
                    $("#Barrio").append("<option value='" + item.value + "'>" + item.text + "</option>");
                });
            });
        } else {
            $("#Barrio").empty();
        }
    });

    // Cargar provincias al inicio
    $.getJSON("/Personas/GetProvincias", function (data) {
        $.each(data, function (index, item) {
            $("#Provincia").append("<option value='" + item.value + "'>" + item.text + "</option>");
        });
    });

    //$(document).ready(function () {
    //    // Captura el cambio en el campo tipoCedula
    //    $('[name="Persona.tipoCedula"]').on('change', function () {
    //        // Obtén el valor seleccionado
    //        var tipoCedula = $(this).val();

    //        // Si es "Juridico", selecciona automáticamente "No Aplica" en Sexo
    //        if (tipoCedula === '2') {
    //            $('#sexoNoAplica').prop('checked', true);
    //            // Rellena los campos "Apellido" y "Apellido2" con 'No aplica'
    //            $('[name="Persona.Apellido"]').val('No aplica').prop('readonly', true);
    //            $('[name="Persona.Apellido2"]').val('No aplica').prop('readonly', true);
    //        } else {
    //            $('#sexoNoAplica').prop('checked', false);
    //            // Habilita los campos "Apellido" y "Apellido2"
    //            $('[name="Persona.Apellido"]').val('').prop('readonly', false);
    //            $('[name="Persona.Apellido2"]').val('').prop('readonly', false);
    //        }
    //    });
    //});

});
$('#staticBackdrop').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget); // Button that triggered the modal
    var modal = $(this);

    modal.find('#detalleCedula').text(button.data('id'));

    var ClienteId = button.data('id');
    $('[name="Id"]').val(ClienteId); // Asignar el ID del cliente al campo de formulario oculto
});

// Example starter JavaScript for disabling form submissions if there are invalid fields
(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()