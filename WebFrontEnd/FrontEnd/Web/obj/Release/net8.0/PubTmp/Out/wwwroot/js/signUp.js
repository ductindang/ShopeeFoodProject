
$(document).ready(function () {
    $('#togglePassword').on('click', function () {
        var passwordField = $('#Password');
        var passwordFieldType = passwordField.attr('type');

        if (passwordFieldType === 'password') {
            passwordField.attr('type', 'text');
            $(this).html('<i class="bi bi-eye-slash"></i>');
        } else {
            passwordField.attr('type', 'password');
            $(this).html('<i class="bi bi-eye"></i>');
        }
    });
});

function validatePhoneNumber() {
    const phoneNumber = document.getElementById("PhoneNumber").value;
    const phoneNumberError = document.getElementById("phone-number-error");
    const phoneRegex = /^0\d{9}$/;

    if (phoneNumber.length > 0) {
        if (!phoneRegex.test(phoneNumber)) {
            phoneNumberError.textContent = 'Phone number must be 10 digits and start with 0';
            return false;
        }

        phoneNumberError.textContent = '';
        return true;
    } else {
        phoneNumberError.textContent = '';
        return false;
    }
}

function checkEmailExists() {
    const email = document.getElementById('Email').value;
    const emailError = document.getElementById('email-error');

    if (email.length > 0) {
        $.ajax({
            type: 'Get',
            //url: 'https://localhost:7059/User/CheckEmailExist',
            url: checkEmailUrl,
            data: { email: email },
            success: function (result) {
                if (result) {
                    emailError.textContent = 'This email is already in use';
                } else {
                    emailError.textContent = '';
                }
            }
        });
    } else {
        emailError.textContent = '';
    }
}

function validatePassword() {
    const password = document.getElementById("Password").value;
    const passwordError = document.getElementById("password-error");

    const lengthRegex = /.{8,}/;
    const upperCaseRegex = /[A-Z]/;
    const lowerCaseRegex = /[a-z]/;
    const numberRegex = /[0-9]/;
    const specialCharRegex = /[!#$%\^\&*\)\(+=._-]/;

    let errorMessage = [];
    if (!lengthRegex.test(password)) {
        errorMessage.push('Password must be at least 8 characters long');
    }
    if (!upperCaseRegex.test(password)) {
        errorMessage.push('at least one uppercase letter');
    }
    if (!lowerCaseRegex.test(password)) {
        errorMessage.push('at least one lowercase letter');
    }
    if (!numberRegex.test(password)) {
        errorMessage.push('at least one number');
    }
    if (!specialCharRegex.test(password)) {
        errorMessage.push('at least one special character');
    }

    passwordError.textContent = errorMessage.join(', ');

    return errorMessage.length === 0;
}

document.getElementById('sign-up-form').addEventListener('submit', function (event) {
    if (!validatePhoneNumber() || !validatePassword()) {
        event.preventDefault();
    }
});