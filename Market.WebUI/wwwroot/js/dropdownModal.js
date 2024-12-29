$('#Settings').on('click', function () {
    const button = $(this);
    const modal = $('#DropdownModalSettings');

    if (modal.is(':visible')) modal.hide();
    else {
        var offset = button.offset();
        var modalWidth = modal.outerWidth();

        modal.css({
            top: offset.top + button.outerHeight(),
            left: offset.left - modalWidth
        }).show();
    }
});

$('#CloseDropdownModalSettingsButton').on('click', function () {
    $('#DropdownModalSettings').hide()
});