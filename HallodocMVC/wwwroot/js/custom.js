function passtoggle() {
    var x = document.getElementById("floatingPassword");
    if (x.type === "password") {
        x.type = "text";
        document.querySelectorAll(".fa-eye").forEach(i => i.style.display = "none");
        document.querySelectorAll(".fa-eye-slash").forEach(i => i.style.display = "block");
    }
    else {
        x.type = "password";
        document.querySelectorAll(".fa-eye-slash").forEach(i => i.style.display = "none");
        document.querySelectorAll(".fa-eye").forEach(i => i.style.display = "block");
    }
}
$("#files").change(function () {
    filename = this.files[0].name;
    console.log(filename);
    $("#choosenfile").text(filename);
});
const phoneInputField2 = document.querySelector("#phone");
const phoneInput2 = window.intlTelInput(phoneInputField2, {
    utilsScript:
        "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
});
const phoneInputField1 = document.querySelector("#phone1");
const phoneInput1 = window.intlTelInput(phoneInputField1, {
    utilsScript:
        "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
});
