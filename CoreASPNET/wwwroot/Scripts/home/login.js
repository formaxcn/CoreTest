var HomeLogin = (function () {
    var bindEvent = function () {
        $('#loginForm').validate({
            rules: {
                email: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength:6
                }
            },
            message: {
                email: "Please enter a valid email address",
                password: {
                    required: "Please provide a password",
                    minlength: "More than 6 characters needed"
                }
            }
        });

        $('#loginBtn').on('click', function () {
            if ($('#loginForm').valid()) {
                var mail = $('#inputEmail').val();
                var pass = $('#inputPassword').val();
                var rememberMe = $('#rememberCheck')[0].checked;
                debugger;
            }
        });
    };
    return {
        init: function () {
            bindEvent();
        }
    }
}());

$(document).ready(function () {
    HomeLogin.init();
});