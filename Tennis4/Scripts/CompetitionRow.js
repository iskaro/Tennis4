$(function () {
    $('#Competition').change(function () {
        $.getJSON('/CompetitionEnrollment/GetRows/' + $('#Competition').val(), function (data) {
            var items = '<option>Select a row</option>';
            $.each(data, function (i, row) {
                items += "<option value='" + row.Value + "'>" + row.Text + "</option>";
            });
            $('#Row').html(items);
        });
    });
});