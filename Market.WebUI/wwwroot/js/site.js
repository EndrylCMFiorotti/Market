const body = document.body;

$(window).on('load', function () {
    var isDarkMode = localStorage.getItem("IsDarkMode") === 'true';
    $('#ToggleButton').prop('checked', isDarkMode);
    $('body').toggleClass('dark-mode', isDarkMode);
    $('body').toggleClass('light-mode', !isDarkMode);

    var isSidebarOpen = localStorage.getItem("IsSidebarOpen") === 'true';
    verifyOpenMenu(isSidebarOpen);
})

$('#ToggleButton').on('change', function () {
    $('body').toggleClass('dark-mode');
    $('body').toggleClass('light-mode');
    localStorage.setItem("IsDarkMode", $(this).is(':checked'));
});

$('#Menu').on('click', function () {
    var isSidebarOpen = $('.sidebar').hasClass('open');
    localStorage.setItem("IsSidebarOpen", isSidebarOpen);
    verifyOpenMenu(isSidebarOpen);
});

function verifyOpenMenu(isSidebarOpen) {
    if (isSidebarOpen) {
        $('.sidebar').removeClass('open').addClass('close');
        $('.content').removeClass('minimized').addClass('expanded');
    } else {
        $('.sidebar').removeClass('close').addClass('open');
        $('.content').removeClass('expanded').addClass('minimized');
    }
}

function openToast(message, isSuccess) {
    closeModal('modalLogin');
    if (isSuccess) closeModal('DropdownModalSettings');
    const myToast = $('#Toast');
    myToast.children().text(message);
    myToast.removeClass(!isSuccess ? 'bg-success' : 'bg-danger').addClass(isSuccess ? 'bg-success' : 'bg-danger');
    bootstrap.Toast.getOrCreateInstance(myToast).show();
}

function openModal(nomeModal) {
    $(`#${nomeModal}`).show();
}

function closeModal(nomeModal) {
    $(`#${nomeModal}`).hide();
}

$('#cmdLogout').on('click', function (event) {
    $.ajax({
        url: '/Base/Logout',
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            window.location.href = '/Home/Index';
        },
        error: function (xhr, status, error) {
            openToast(xhr.message, xhr.success);
        }
    });
});