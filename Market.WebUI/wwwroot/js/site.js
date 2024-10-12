$(document).on("ready", function () {
    const body = document.body;

    $('#ToggleButton').on('click', () => {
        body.classList.toggle('dark-mode');
        body.classList.toggle('light-mode');
    });
});

$('#menu').on('click', function () {
    var isSidebarOpen = $('.sidebar').hasClass('open');
    if (isSidebarOpen) {
        $('.sidebar').removeClass('open').addClass('close');
        $('.content').removeClass('minimized').addClass('expanded');
    } else {
        $('.sidebar').removeClass('close').addClass('open');
        $('.content').removeClass('expanded').addClass('minimized');
    }
});