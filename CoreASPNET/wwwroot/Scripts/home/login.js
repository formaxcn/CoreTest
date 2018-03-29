var HomeLogin = (function () {
    var SHA512 = new Hashes.SHA512();
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

                var hashPass = SHA512.hex(BCrypt.hashSync(SHA512.hex(pass) + mail));
                $.ajax({
                    type: "post",
                    url: "/Home/LoginUser",
                    async: false,
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