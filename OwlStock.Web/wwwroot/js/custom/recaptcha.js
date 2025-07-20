const scriptTag = document.currentScript;
const siteKey = scriptTag.getAttribute("data-siteKey");

var onloadCallback = function () {
    grecaptcha.render('recaptcha-container', {
        'sitekey': siteKey
    });
};

function onSubmit() {
    if (typeof grecaptcha !== 'undefined') {
        const token = grecaptcha.getResponse();
        document.getElementById('recaptchaTokenInputId').value = token;
    } else {
        console.error('reCAPTCHA not loaded or unavailable');
    }
}