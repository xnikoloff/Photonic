const passwordField = document.getElementById("Input_Password");
const confirmPasswordField = document.getElementById("Input_ConfirmPassword");
const togglePasswordWrap = document.querySelector(".password-toggle-icon");
const togglePassword = document.querySelector(".password-toggle-icon i");

togglePasswordWrap.addEventListener("click", function () {
    
    toggleVisibility(passwordField);
    toggleVisibility(confirmPasswordField);
});


function toggleVisibility(input) {
    if (input.type === "password") {
        input.type = "text";
        togglePassword.classList.remove("fa-eye");
        togglePassword.classList.add("fa-eye-slash");
    } else {
        input.type = "password";
        togglePassword.classList.remove("fa-eye-slash");
        togglePassword.classList.add("fa-eye");
    }
}