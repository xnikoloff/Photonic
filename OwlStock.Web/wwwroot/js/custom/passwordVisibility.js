const passwordField = document.getElementById("Input_Password");
const togglePasswordWrap = document.querySelector(".password-toggle-icon");
const togglePassword = document.querySelector(".password-toggle-icon i");

togglePasswordWrap.addEventListener("click", function () {
    if (passwordField.type === "password") {
        passwordField.type = "text";
        togglePassword.classList.remove("fa-eye");
        togglePassword.classList.add("fa-eye-slash");
    } else {
        passwordField.type = "password";
        togglePassword.classList.remove("fa-eye-slash");
        togglePassword.classList.add("fa-eye");
    }
});