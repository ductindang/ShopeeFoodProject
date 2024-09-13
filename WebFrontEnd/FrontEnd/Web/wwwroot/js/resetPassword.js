
document.addEventListener('DOMContentLoaded', function () {
    // Toggle password visibility
    function togglePasswordVisibility(buttonId, inputId) {
        const button = document.getElementById(buttonId);
        const input = document.getElementById(inputId);

        button.addEventListener('click', function () {
            const type = input.type === 'password' ? 'text' : 'password';
            input.type = type;
            button.innerHTML = type === 'password' ? '<i class="bi bi-eye"></i>' : '<i class="bi bi-eye-slash"></i>';
        });
    }

    togglePasswordVisibility('toggleNewPassword', 'NewPassword');
    togglePasswordVisibility('toggleConfirmPassword', 'ConfirmPassword');

    // Validate form on submit
    document.getElementById('reset-password-form').addEventListener('submit', function (event) {
        const newPassword = document.getElementById('NewPassword').value;
        const confirmPassword = document.getElementById('ConfirmPassword').value;
        const errorElement = document.getElementById('password-confirm-error');

        if (newPassword !== confirmPassword) {
            errorElement.textContent = 'Passwords do not match.';
            event.preventDefault(); // Prevent form submission
        } else {
            errorElement.textContent = '';
        }
    });


    
});


