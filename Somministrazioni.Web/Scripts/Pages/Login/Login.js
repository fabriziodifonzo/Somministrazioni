$(document).ready(function () {

    function HandleAuthenticationData(data) {
        if (data.ErrorCode == ERRCODE_INVALIDLOGIN) {
            HandleInvalidLogin(data);
        }
        else {
            window.location = homeUrl;
        }
    }

    function HandleInvalidLogin(data) {
        var paragraph = $("#infoPanel").children().eq(0);
        paragraph.text(data.ErrorMsg);
    }

    $("#loginFormID").submit(function (e) {

        e.preventDefault(); // avoid to execute the actual submit of the form.

        var form = $(this);

        $.ajax({
            type: "POST",
            url: loginlUrl,
            data: form.serialize(),
            success: function (data) {
                HandleAuthenticationData(data);
            },
            error: function (request, error) {
                window.location = errorUrl;
            },
        });
    });
});