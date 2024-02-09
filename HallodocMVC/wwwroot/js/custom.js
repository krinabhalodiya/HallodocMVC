swal({
    title: "Information",
    text: "When submitting a request, you must provide the correct contact information for the patient or the responsibly party. Failure to provide the correct email and phone number will delay service or be declined.",
    type: "warning",
    confirmButtonColor: "#0dcaf0",    
});
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
    console.log("function");
    filename = this.files[0].name;
    $("#choosenfile").text(filename);
});
const phoneInputField = document.querySelector("#phone");
const phoneInput = window.intlTelInput(phoneInputField, {
    utilsScript:
        "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
});
const phoneInputField1 = document.querySelector("#phone1");
const phoneInput1 = window.intlTelInput(phoneInputField1, {
    utilsScript:
        "https://cdnjs.cloudflare.com/ajax/libs/intl-tel-input/17.0.8/js/utils.js",
});

