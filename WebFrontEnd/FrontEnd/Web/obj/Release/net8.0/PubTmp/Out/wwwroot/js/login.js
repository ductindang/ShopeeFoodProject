
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

function reloadLoginPage(event) {
    //event.preventDefault(); // Prevent the default form submission

    $.ajax({
        type: 'POST',
        //url: 'https://localhost:7059/User/CheckLogin',
        url: checkLoginUrl,
        data: {
            Email: $('#email').val(),
            Password: $('#password').val(),
        },
        success: function (response) {
            if (response.success) {
                // Check if there's a saved redirect URL
                var redirectUrl = localStorage.getItem('cartRedirect');
                if (redirectUrl) {
                    // Remove the redirect URL from localStorage
                    localStorage.removeItem('cartRedirect');
                    // Redirect to the saved URL
                    window.location.href = redirectUrl;
                } else {
                    // No saved URL, redirect to homepage or another default page
                    //window.location.href = "https://localhost:7059/";
                    window.location.href = homeUrl;
                }
            } else {
                // Show error message if login fails
                $('#error-message').text(response.message);
            }
        },
    });
}



document.getElementById('login-form').addEventListener('submit', function (e) {
    e.preventDefault();

    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;
    var rememberMe = document.getElementById('rememberMe').checked;

    var data = {
        Email: email,
        Password: password,
        RememberMe: rememberMe
    };

    fetch('/User/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(result => {
            if (result.success) {
                window.location.href = result.redirectUrl;
            } else {
                document.getElementById('error-message').innerText = result.message;
            }
        });
});
