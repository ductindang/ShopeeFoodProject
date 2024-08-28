
$(document).ready(function () {
    $('#togglePassword').on('click', function () {
        var passwordField = $('#password');
        var passwordFieldType = passwordField.attr('type');

        if (passwordFieldType === 'password') {
            passwordField.attr('type', 'text');
            $(this).removeClass('bi-eye').addClass('bi-eye-slash');
        } else {
            passwordField.attr('type', 'password');
            $(this).removeClass('bi-eye-slash').addClass('bi-eye');
        }
    });
});

function reloadLoginPage() {
    event.preventDefault();

    $.ajax({
        type: 'POST',
        url: 'https://localhost:7059/User/CheckLogin',
        data: {
            Email: $('#email').val(),
            Password: $('#password').val(),
        },
        success: function (response) {
            if (response.success) {
                window.location.href = response.redirectUrl;
            } else {
                $('#error-message').text(response.message);
            }
        },
    });
}