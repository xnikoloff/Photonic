const scriptTag = document.currentScript;
const siteKey = scriptTag.getAttribute("data-siteKey");

var onloadCallback = function () {
    grecaptcha.render('recaptcha-container', {
        'sitekey': siteKey
    });
};

function onSubmit() {
    document.getElementById('recaptchaTokenInputId').value = grecaptcha.getResponse();
}

function recaptchaCallback() {
    document.getElementById('btn-account-submit').disabled = false;
}