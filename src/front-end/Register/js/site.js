function validatePhone() {
    var phone = document.getElementById("phone");
    var pattern = /^(03|05|07|08|09)+\d{1}[-\s]?\d{3}[-\s]?\d{4}$/;
    if (pattern.test(phone.value)) {
        phone.setCustomValidity('');       
    }
    else {
        phone.setCustomValidity("Số điện thoại đã nhập không tồn tại.");
    }
}

phone.onkeyup = validatePhone;

var password = document.getElementById("password")
    , confirm_password = document.getElementById("confirm_password");

function validatePassword() {
    if (password.value != confirm_password.value) {
        confirm_password.setCustomValidity("Mật khẩu đã nhập không trùng khớp.");
    } else {
        confirm_password.setCustomValidity('');
    }
}

password.onchange = validatePassword;
confirm_password.onkeyup = validatePassword;