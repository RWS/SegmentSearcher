$(function () {
    $('select[name="file-filter"]').change(function (event) {
        var allCount = $('#all-count').text();
        $('#filtered-count').text(allCount);
        var fileId = $(this).val();
        $('#results tbody').show();
        if (fileId !== '#ALL#') {
            var hiddenTbodies = $('td.file-id:not(:contains("' + fileId + '"))').closest('tbody');
            $('#filtered-count').text(allCount - hiddenTbodies.size());
            hiddenTbodies.hide();
        }
    });
});