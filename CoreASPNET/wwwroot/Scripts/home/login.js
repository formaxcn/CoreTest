var HomeLogin = (function () {
    var SHA256 = new Hashes.SHA256();
    var BCrypt = dcodeIO.bcrypt;

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
                password: {
                    minlength: "More than 6 characters needed"
                }
            }
        });

        $('#loginBtn').on('click', function () {
            if ($('#loginForm').valid()) {
                var mail = $('#inputEmail').val();
                var pass = $('#inputPassword').val();
                var rememberMe = $('#rememberCheck')[0].checked;

                var hashPass = BCrypt.hashSync(mail + SHA256.hex(pass));
                $.ajax({
                    type: "post",
                    url: "/Home/LoginUser",
                    dataType:"json",
                    data: {
                        "Email": mail,
                        "HashPass": hashPass
                    },
                    success: function (rusult) {
                        //todo: redirect to user index page
                        debugger;
                    }
                });
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