$(document).ready(function () {
    var userCheckJson = localStorage.getItem('userCheck')
    if (userCheckJson) {
        var userCheck = JSON.parse(userCheckJson);
        if (userCheck.Gender == 0) {
            $('#genderMale').prop('checked', true);
        } else if (userCheck.Gender == 1) {
            $('#genderFemale').prop('checked', true);
        } else if (userCheck.Gender == 2) {
            $('#genderOther').prop('checked', true);
        }
    } else {
        $('#genderMale').prop('checked', true);
    }
});



function openModal(img) {
    var modal = document.getElementById("avatarModal");
    var modalImg = document.getElementById("modalImage");
    var captionText = document.getElementById("caption");

    modal.style.display = "block";
    modalImg.src = img.src;
    captionText.innerHTML = img.alt; // Use the alt text of the image for caption
}

function closeModal() {
    var modal = document.getElementById("avatarModal");
    modal.style.display = "none";
}

// Close the modal if the user clicks anywhere outside of the modal
window.onclick = function (event) {
    var modal = document.getElementById("imgAvatarModel");
    var modalAvatar = document.getElementById("avatarModal");
    if (event.target == modal || event.target == modalAvatar) {
        modalAvatar.style.display = "none";
    }
}





function handleInputChange() {
    const input = document.getElementById('avatarInput');
    const img = document.getElementById('avatarPreview');
    const resetButton = document.getElementById('resetButton');

    // Update the image source to the new input value
    img.src = input.value || input.getAttribute('data-default-avatar');

    if (input.value) {
        resetButton.style.backgroundColor = '#4073a7'; // Change to active color
        resetButton.style.color = 'white';
        resetButton.style.cursor = 'pointer';
        resetButton.disabled = false; // Enable the reset button
    } else {
        resetButton.style.backgroundColor = '#ccc'; // Inactive color
        resetButton.style.color = '#666';
        resetButton.style.cursor = 'not-allowed';
        resetButton.disabled = true; // Disable the reset button
    }
}

//function resetAvatar() {
//    const input = document.getElementById('avatarInput');
//    const img = document.getElementById('avatarPreview');
//    const defaultAvatarUrl = input.getAttribute('data-default-avatar'); // Get avatar URL from data attribute

//    input.value = ''; // Clear the input field
//    img.src = defaultAvatarUrl; // Reset the image to the original avatar

//    // Set the reset button to its disabled state
//    const resetButton = document.getElementById('resetButton');
//    resetButton.style.backgroundColor = '#ccc';
//    resetButton.style.color = '#666';
//    resetButton.style.cursor = 'not-allowed';
//    resetButton.disabled = true;
//}



// --------------------------- Edit user info ------------------------------
updateEmailButton = document.getElementById('updateEmailButton');
emailField = document.getElementById('emailField');
cancelEmailButton = document.getElementById('cancelEmailButton');
email = document.getElementById('emailInput');
emailError = document.getElementById('email-error');


updateEmailButton.addEventListener('click', function () {
    emailField.classList.remove('hidden');
    updateEmailButton.classList.add('hidden');
});

cancelEmailButton.addEventListener('click', function () {
    email.value = '';
    emailError.textContent = '';
    emailField.classList.add('hidden');
    updateEmailButton.classList.remove('hidden');
});

// Password Update Functionality
var updatePasswordDiv = document.getElementById('updatePasswordDiv'); 
updatePasswordButton = document.getElementById('updatePasswordButton');
passwordFields = document.getElementById('passwordFields');
newPassword = document.getElementById('newPasswordInput');
confirmNewPassword = document.getElementById('confirmPasswordInput');
passwordError = document.getElementById("password-error");
errorElement = document.getElementById('password-confirm-error');
cancelPasswordButton = document.getElementById('cancelPasswordButton');

updatePasswordButton.addEventListener('click', function () {
    passwordFields.classList.remove('hidden');
    updatePasswordDiv.classList.add('hidden');
});

cancelPasswordButton.addEventListener('click', function () {
    newPassword.value = '';
    confirmNewPassword.value = '';
    passwordError.textContent = '';
    errorElement.textContent = '';
    passwordFields.classList.add('hidden');
    updatePasswordDiv.classList.remove('hidden');
});

// Handle the reset button state
nameInput = document.getElementById('nameInput');
genderRadios = document.querySelectorAll('input[name="Gender"]');
emailInput = document.getElementById('emailInput');
newPasswordInput = document.getElementById('newPasswordInput');
confirmPasswordInput = document.getElementById('confirmPasswordInput');
resetInfoButton = document.getElementById('resetInfoButton');


// Store initial values
initialValues = {
    name: nameInput ? nameInput.value : '',
    gender: Array.from(genderRadios).find(r => r.checked) ? Array.from(genderRadios).find(r => r.checked).value : '',
    email: emailInput ? emailInput.value : '',
    newPassword: newPasswordInput ? newPasswordInput.value : '',
    confirmPassword: confirmPasswordInput ? confirmPasswordInput.value : ''
};

function hasChanges() {
    const currentGender = Array.from(genderRadios).find(r => r.checked) ? Array.from(genderRadios).find(r => r.checked).value : '';
    return nameInput.value !== initialValues.name ||
        currentGender !== initialValues.gender ||
        emailInput.value !== initialValues.email ||
        newPasswordInput.value !== initialValues.newPassword ||
        confirmPasswordInput.value !== initialValues.confirmPassword;
}

function toggleResetButton() {
    if (hasChanges()) {
        resetInfoButton.style.backgroundColor = '#4073a7';
        resetInfoButton.style.color = 'white';
        resetInfoButton.style.cursor = 'pointer';
        resetInfoButton.disabled = false;
    } else {
        passwordError.textContent = '';
        emailError.textContent = '';
        resetInfoButton.disabled = true;
        resetInfoButton.style.backgroundColor = '#ccc';
        resetInfoButton.style.color = '#666';
        resetInfoButton.style.cursor = 'not-allowed';
    }
}

//function resetFields() {
//    if (nameInput) nameInput.value = initialValues.name;
//    if (genderRadios.length > 0) {
//        genderRadios.forEach(radio => {
//            radio.checked = radio.value === initialValues.gender;
//        });
//    }
//    if (emailInput) emailInput.value = initialValues.email;
//    if (newPasswordInput) newPasswordInput.value = initialValues.newPassword;
//    if (confirmPasswordInput) confirmPasswordInput.value = initialValues.confirmPassword;

//    toggleResetButton(); // Ensure the button is disabled after reset
//}

// Attach event listeners to fields
nameInput.addEventListener('input', toggleResetButton);
genderRadios.forEach(radio => radio.addEventListener('change', toggleResetButton));
if (emailInput) emailInput.addEventListener('input', toggleResetButton);
if (newPasswordInput) newPasswordInput.addEventListener('input', toggleResetButton);
if (confirmPasswordInput) confirmPasswordInput.addEventListener('input', toggleResetButton);

// Attach event listener to the Reset button
//resetInfoButton.addEventListener('click', resetFields);


//-------------------------------------------------------------------------------------


function handleInputPhoneChange() {
    const input = document.getElementById('phoneInput');
    const resetButton = document.getElementById('resetPhoneButton');

    // Update the image source to the new input value
    const defaultPhoneNumber = phoneInput.getAttribute('data-default-phone');

    if (phoneInput.value !== defaultPhoneNumber) {
        resetButton.style.backgroundColor = '#4073a7'; // Change to active color
        resetButton.style.color = 'white';
        resetButton.style.cursor = 'pointer';
        resetPhoneButton.disabled = false;
    } else {
        resetButton.style.backgroundColor = '#ccc'; // Inactive color
        resetButton.style.color = '#666';
        resetButton.style.cursor = 'not-allowed';
        resetPhoneButton.disabled = true;
    }
}


//function resetPhoneNumber() {
//    const input = document.getElementById('phoneInput');
//    const defaultPhoneNumber = phoneInput.getAttribute('data-default-phone');

//    input.value = defaultPhoneNumber; // Clear the input field

//    // Set the reset button to its disabled state
//    const resetButton = document.getElementById('resetPhoneButton');
//    resetButton.style.backgroundColor = '#ccc';
//    resetButton.style.color = '#666';
//    resetButton.style.cursor = 'not-allowed';
//    resetButton.disabled = true;
//}




//document.addEventListener("DOMContentLoaded", function () {
//    const updateUserButton = document.getElementById("updateUser");

//    // Get all input fields and select elements
//    const inputs = document.querySelectorAll("input[type='text'], input[type='password'], input[type='email'], select");

//    // Store initial values of all input fields
//    initialValues = Array.from(inputs).map(input => input.value);

//    // Function to check for changes in any input
//    function checkForChanges() {
//        let hasChanges = false;

//        inputs.forEach((input, index) => {
//            if (input.value !== initialValues[index]) {
//                hasChanges = true;
//            }
//        });

//        // Show or hide the update button based on changes
//        updateUserButton.style.display = hasChanges ? "block" : "none";
//    }

//    // Attach event listeners to all input fields and select elements
//    inputs.forEach(input => {
//        input.addEventListener("input", checkForChanges);
//        input.addEventListener("change", checkForChanges);  // For select elements
//    });

//    // Initially hide the update button
//    updateUserButton.style.display = "none";
//});




function validatePhoneNumber() {
    const phoneNumber = document.getElementById("phoneInput").value;
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
    const email = document.getElementById('emailInput').value;
    const emailError = document.getElementById('email-error');
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    emailError.textContent = '';

    if (email.length > 0) {
        if (!emailPattern.test(email)) {
            emailError.textContent = 'Please enter a valid email address';
            return;
        }
        emailError.textContent = 'Checking email availability...';
        $.ajax({
            type: 'GET',
            //url: 'https://localhost:7059/User/CheckEmailExist',
            url: checkEmailUrl,
            data: { email: email },
            success: function (result) {
                if (result) {
                    emailError.textContent = 'This email is already in use';
                } else {
                    emailError.textContent = '';
                }
            },
            error: function () {
                emailError.textContent = 'An error occurred while checking the email. Please try again later.';
            }
        });
    } else {
        emailError.textContent = '';
    }
}



$(document).ready(function () {
    $('#togglePassword').on('click', function () {
        var passwordField = $('#newPasswordInput');
        var confirmPass = $('#confirmPasswordInput')
        var passwordFieldType = passwordField.attr('type');

        if (passwordFieldType === 'password') {
            passwordField.attr('type', 'text');
            confirmPass.attr('type', 'text');
            $(this).html('<i class="bi bi-eye-slash"></i>');
        } else {
            passwordField.attr('type', 'password');
            confirmPass.attr('type', 'password');
            $(this).html('<i class="bi bi-eye"></i>');
        }
    });
});


function validatePassword() {
    const password = document.getElementById("newPasswordInput").value;
    const passwordError = document.getElementById("password-error");

    const lengthRegex = /.{8,}/;
    const upperCaseRegex = /[A-Z]/;
    const lowerCaseRegex = /[a-z]/;
    const numberRegex = /[0-9]/;
    const specialCharRegex = /[!@#$%^&*()+=._-]/;

    let errorMessage = [];
    if (password == '') {
        passwordError.textContent = '';
    } else {
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
    }
    passwordError.textContent = errorMessage.join(', ');

    return errorMessage.length === 0;
}



document.getElementById('update-account-form').addEventListener('submit', function (event) {
    const newPassword = document.getElementById('newPasswordInput').value;
    const confirmPassword = document.getElementById('confirmPasswordInput').value;
    const errorElement = document.getElementById('password-confirm-error');

    if (newPassword !== confirmPassword) {
        errorElement.textContent = 'Passwords do not match.';
        event.preventDefault(); // Prevent form submission
    } else {
        errorElement.textContent = '';
    }
});


document.getElementById('update-account-form').addEventListener('submit', function (event) {
    if (!validatePhoneNumber() || !validatePassword()) {
        event.preventDefault();
    }
});


