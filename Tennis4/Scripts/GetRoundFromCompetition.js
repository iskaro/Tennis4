$(function () {

    function populateRound() {
        $.getJSON('/CompetitionEnrollment/GetRounds/' + $('#Competition').val(), function (data) {
            //var items = '<option value ="">Select round</option>';
            var items;
            $.each(data, function (i, round) {
                items += "<option value='" + round.Value + "'>" + round.Text + "</option>";
            });
            $('#roundId').html(items);
        });
    }

    $(document).ready(function () {
        populateRound();
    });


    $('#Competition').change(function () {
        populateRound();
    });
    //$(document).ready(function () {
    //    $.getJSON('/CompetitionEnrollment/GetRounds/' + $('#Competition').val(), function (data) {
    //        var items = '<option value ="">Select round</option>';
    //        $.each(data, function (i, round) {
    //            items += "<option value='" + round.Value + "'>" + round.Text + "</option>";
    //        });
    //        $('#roundId').html(items);
    //    });
    //});
});