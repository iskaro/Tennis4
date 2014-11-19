$(function () {
    $('#Competition').change(function () {
        if (document.getElementById('Competition').value == "") {
            document.getElementById("RoundDiv").hidden = true;
            document.getElementById("RowDiv").hidden = true;
            document.getElementById("PositionDiv").hidden = true;
            document.getElementById("Round").value = "";
            document.getElementById("Row").value = "";
            document.getElementById("RowPosition").value = "";
        } else {
            document.getElementById("RoundDiv").hidden = false;
            document.getElementById("RowDiv").hidden = true;
            document.getElementById("PositionDiv").hidden = true;
            document.getElementById("Row").value = "";
            document.getElementById("RowPosition").value = "";
        }
        
        $.getJSON('/CompetitionEnrollment/GetRounds/' + $('#Competition').val(), function (data) {
            var items = '<option value ="">Select round</option>';
            $.each(data, function (i, round) {
                items += "<option value='" + round.Value + "'>" + round.Text + "</option>";
            });
            $('#Round').html(items);
        });
    });

    $('#Round').change(function () {
        if (document.getElementById('Round').value == "") {
            document.getElementById("RowDiv").hidden = true;
            document.getElementById("PositionDiv").hidden = true;
            document.getElementById("Row").value = "";
            document.getElementById("RowPosition").value = "";
        } else {
            document.getElementById("RowDiv").hidden = false;
            document.getElementById("PositionDiv").hidden = true;
            document.getElementById("RowPosition").value = "";
        }

        $.getJSON('/CompetitionEnrollment/GetRows/' + $('#Round').val(), function (data) {
            var items = '<option value ="">Select a row</option>';
            $.each(data, function (i, row) {
                items += "<option value='" + row.Value + "'>" + row.Text + "</option>";
            });
            $('#Row').html(items);
        });
    });

    $('#Row').change(function () {
        if (document.getElementById('Row').value == "") {
            document.getElementById("PositionDiv").hidden = true;
            document.getElementById("RowPosition").value = "";
        } else {
            document.getElementById("PositionDiv").hidden = false;
            document.getElementById("RowPosition").value = "";
        }

        $.getJSON('/CompetitionEnrollment/GetRowPositions/' + $('#Competition').val(), function (data) {
            var items = '<option value ="">Select position in row</option>';
            $.each(data, function (i, position) {
                items += "<option value='" + position.Value + "'>" + position.Text + "</option>";
            });
            $('#RowPosition').html(items);
        });
    });
});