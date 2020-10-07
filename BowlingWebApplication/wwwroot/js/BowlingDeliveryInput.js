$(document).ready(function (parameters) {
    $("#dpDnDeliveryCode").on('change', function () {
        let prevPinsDown = Number($("#prevPinsDown").val());
        let availablePinsCt = 10 - prevPinsDown; 
        switch ($(this).val()) {
        case '1': //strike
            $('#dpDnPinsDown').prop('disabled', true);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            $("#dpDnPinsDown").append($('<option></option>').val(10).html('10'));
            $("#dpDnPinsDown").val(10);
            break;
        case '2'://spare
            $('#dpDnPinsDown').prop('disabled', true);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            $("#dpDnPinsDown").append($('<option></option>').val(availablePinsCt).html(availablePinsCt));
            $("#dpDnPinsDown").val(availablePinsCt);
            break;
        case '3': //open frame
            $('#dpDnPinsDown').prop('disabled', true);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            $("#dpDnPinsDown").append($('<option></option>').val(0).html('0'));
            $("#dpDnPinsDown").val(0);
            break;
        case '4': //split
            $('#dpDnPinsDown').prop('disabled', false);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            for (var i = 1; i <= 8 - prevPinsDown; i++) {
                $("#dpDnPinsDown").append($('<option></option>').val(i).html(i));
            }
            break;
        case '5': //foul
            $('#dpDnPinsDown').prop('disabled', true);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            $("#dpDnPinsDown").append($('<option></option>').val(0).html('0'));
            $("#dpDnPinsDown").val(0);
            break;
        case '6': //standard roll
            $('#dpDnPinsDown').prop('disabled', false);
            $('#dpDnPinsDown option').remove();
            $("#dpDnPinsDown").append($('<option></option>').val('').html('-select-'));
            for (var i = 1; i <= 9 - prevPinsDown; i++) {
                    $("#dpDnPinsDown").append($('<option></option>').val(i).html(i));
            }
            break;
        default:

        }
    });
});