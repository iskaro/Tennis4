$(function () {
    $('#Competition').change(function () {
        $.getJSON('/CompetitionRow/GetRounds/' + $('#Competition').val(), function (data) {
            var items = '<option>Select round</option>';
            $.each(data, function (i, round) {
                items += "<option value='" + round.Value + "'>" + round.Text + "</option>";
            });
            $('#Round').html(items);
        });
    });
});