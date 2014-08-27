//$(function () {

//    $('#RowDivID').hide();
//    $('#SubmitID').hide();

//    $('#CompetitionID').change(function () {
//        var URL = $('#CompetitionRowFormID').data('rowListAction');
//        $.getJSON(URL + '/' + $('#CompetitionID').val(), function (data) {
//            var items = '<option>Select a row</option>';
//            $.each(data, function (i, row) {
//                items += "<option value='" + row.Value + "'>" + row.Text + "</option>";
//                // state.Value cannot contain ' character. We are OK because state.Value = cnt++;
//            });
//            $('#RowID').html(items);
//            $('#RowDivID').show();

//        });
//    });

//    $('#RowID').change(function () {
//        $('#SubmitID').show();
//    });
//});

