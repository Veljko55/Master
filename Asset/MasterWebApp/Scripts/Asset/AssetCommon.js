$.ajaxSetup({
    statusCode: {
        401: function (response) {
            var returnUrl = encodeURI(window.location.pathname + window.location.search);
            var loginUrl = '/User/Login?ReturnUrl=' + returnUrl;

            window.location.href = loginUrl;
        }
    }
});